using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IMarkService
    {
        Task<List<Mark>> GetAll();
        Task<Mark> Get(int id);
    }
}