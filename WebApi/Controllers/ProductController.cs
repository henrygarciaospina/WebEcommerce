using DataAccess.Specifications;
using DTOs.Products;
using DTOs.Shared;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Services.Implementations.Products;
using System;
using System.Threading.Tasks;
using WebApi.Errors;
namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
                
         }

        //http://localhost:20122/api/product
        [HttpGet]
        public async Task<ActionResult<Pagination<ProductDto>>> GetProducts([FromQuery] ProductSpecificationParams productParams)
        {
            var product = await _productService.GetAll(productParams);

            if (product == null)
            {
                return NotFound(new CodeErrorResponse(404, $"Aún no hay productos registrados"));
            }

            return Ok(product);
        }

        //http://localhost:20122/api/product/1
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            /* 
             spec = Debe incluir la lógica de la condición de la consulta y también las relaciones
             entre las entidades, entre Producto y Marca, Categoría. 
             */
          
            var product = await _productService.Get(id);

            if (product == null)
            {
                return NotFound(new CodeErrorResponse(404, $"El producto de Id {id} no existe"));
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            var result = await _productService.Post(product);
            if (result == null)
            {
                throw new Exception("No se pudo insertar el producto");
            }

            return Ok(product);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> PutProduct(int id, Product product)
        {
            product.Id = id;
            var result = await _productService.Put(id, product);
            if (result == null)
            {
                throw new Exception("No se pudo actualizar el producto");
            }

            return Ok(product);
        }
    }
}