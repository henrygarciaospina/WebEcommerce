using AutoMapper;
using DataAccess.Interfaces;
using DataAccess.Specifications;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Dtos;
using WebApi.Errors;
namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IGenericRepository<Product> _productRepository;
        private readonly IMapper _mapper;

        public ProductController(IGenericRepository<Product> productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        //http://localhost:20122/api/product
        [HttpGet]
        public async Task<ActionResult<Pagination<ProductDto>>> GetProducts([FromQuery] ProductSpecificationParams productParams)
        {
            var spec = new ProductWithCategoryaAndMarkSpecification(productParams);
            var products = await _productRepository.GetAllWithSpec(spec);

            var specCount = new ProductForCountingSpecification(productParams);
            var totalProducts = await _productRepository.CountAsync(specCount);

            var rounded = Math.Ceiling(Convert.ToDecimal(totalProducts / productParams.PageSize));
            var totalPages = Convert.ToInt32(rounded);

            var data = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductDto>>(products);

            return Ok(
               new Pagination<ProductDto>
               {
                   Count = totalProducts,
                   Data = data,
                   PageCount = totalPages,
                   PageIndex = productParams.PageIndex,
                   PageSize = productParams.PageSize
               }
           );
        }

        //http://localhost:20122/api/product/1
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            /* 
             spec = Debe incluir la lógica de la condición de la consulta y también las relaciones
             entre las entidades, entre Producto y Marca, Categoría. 
             */
            var spec = new ProductWithCategoryaAndMarkSpecification(id);
            var product = await _productRepository.GetByIdWithSpec(spec);

            if (product == null)
            {
                return NotFound(new CodeErrorResponse(404, $"El producto de Id {id} no existe"));
            }

            return _mapper.Map<Product, ProductDto>(product);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> Post(Product product)
        {
            var result = await _productRepository.Add(product);
            if (result == 0)
            {
                throw new Exception("No se pudo insertar el producto");
            }

            return Ok(product);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> Put(int id,  Product product)
        {
            product.Id = id;
            var result= await _productRepository.Update(product);
            if (result == 0)
            {
                throw new Exception("No se pudo actualizar el producto");
            }

            return Ok(product);
        }
    }
}