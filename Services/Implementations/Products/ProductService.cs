using AutoMapper;
using DataAccess.Interfaces;
using DataAccess.Specifications;
using DTOs.Products;
using DTOs.Shared;
using Entities;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Implementations.Products
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Product> _productRepository;

        public ProductService(IGenericRepository<Product> productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<Pagination<ProductDto>> GetAll(ProductSpecificationParams productParams)
        {
            var spec = new ProductWithCategoryaAndMarkSpecification(productParams);
            var products = await _productRepository.GetAllWithSpec(spec);

            var specCount = new ProductForCountingSpecification(productParams);
            var totalProducts = await _productRepository.CountAsync(specCount);

            var rounded = Math.Ceiling(Convert.ToDecimal(totalProducts / productParams.PageSize));
            var totalPages = Convert.ToInt32(rounded);

            var data = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductDto>>(products);

            var response = new Pagination<ProductDto>
            {
                Count = totalProducts,
                Data = data,
                PageCount = totalPages,
                PageIndex = productParams.PageIndex,
                PageSize = productParams.PageSize
            };

            return response;
        }

        public async Task<ProductDto> Get(int id)
        {
            /* 
            spec = Debe incluir la lógica de la condición de la consulta y también las relaciones
            entre las entidades, entre Producto y Marca, Categoría. 
            */
            var productDto = new ProductDto();
            productDto = null;

            var spec = new ProductWithCategoryaAndMarkSpecification(id);
            var product = await _productRepository.GetByIdWithSpec(spec);

            if (product != null)
            {
                return _mapper.Map<Product, ProductDto>(product);
            }

            return productDto;
        }

        public async Task<Product> Post(Product product)
        {
            var result = await _productRepository.Add(product);
            
            if (result == 0)
            {
                product = null;
            }

            return(product);
        }
        public async Task<Product> Put(int id, Product product)
        {
            product.Id = id;
            var result = await _productRepository.Update(product);
            
            if (result == 0)
            {
                product = null;
            }

            return product;
        }

    }
}