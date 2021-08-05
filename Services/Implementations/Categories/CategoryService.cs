using DataAccess.Interfaces;
using Entities;
using Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Implementations.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly IGenericRepository<Category> _categoryRepository;

        public CategoryService(IGenericRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Category> Get(int id)
        {

            return (Category)(await _categoryRepository.GetByIdAsync(id));
        }

        public async Task<List<Category>> GetAll()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return (List<Category>)categories;
        }
    }
}