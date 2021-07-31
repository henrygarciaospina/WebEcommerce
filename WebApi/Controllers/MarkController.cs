using DataAccess.Interfaces;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarkController : ControllerBase
    {
        private readonly IGenericRepository<Mark> _markRepository;

        public MarkController(IGenericRepository<Mark> markRepository)
        {
            _markRepository = markRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Mark>>> GetMarkAll()
        {
            return Ok(await _markRepository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Mark>> GetMarkById(int id)
        {
            return await _markRepository.GetByIdAsync(id);
        }
    }
}