using DataAccess.Interfaces;
using Entities;
using Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Implementations.Marks
{
    public class MarkService : IMarkService
    {
        private readonly IGenericRepository<Mark> _markRepository;

        public MarkService(IGenericRepository<Mark> markRepository)
        {
            _markRepository = markRepository;
        }

        public async Task<Mark> Get(int id)
        {

            return (Mark)(await _markRepository.GetByIdAsync(id));
        }

        public async Task<List<Mark>> GetAll()
        {
            var marks = await _markRepository.GetAllAsync();
            return (List<Mark>)marks;
        }
    }
}