using DataAccess.Specifications;
using DTOs.Products;
using DTOs.Shared;
using Entities;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IProductService
    {
        Task<Pagination<ProductDto>> GetAll(ProductSpecificationParams productParams);
        Task<ProductDto> Get(int id);
        Task<Product> Post(Product product);
        Task<Product> Put(int id, Product product);
    }
}