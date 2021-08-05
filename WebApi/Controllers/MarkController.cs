using Entities;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Errors;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarkController : ControllerBase
    {
        private readonly IMarkService _markService;

        public MarkController(IMarkService markService)
        {
            _markService = markService;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Mark>>> GetMarkAll() 
        {
            var marks = await _markService.GetAll();
            
            if (marks == null)
            {
                return NotFound(new CodeErrorResponse(404, $"Aún no hay marcas registradas"));
            }

            return Ok(marks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Mark>> GetMarkById(int id)
        {
            var mark = await _markService.Get(id);

            if (mark == null)
            {
                return NotFound(new CodeErrorResponse(404, $"La marca de Id {id} no existe"));
            }

            return mark;
        }
    }
}