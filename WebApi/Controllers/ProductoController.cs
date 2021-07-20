using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Dtos;
using WebApi.Errors;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {

        private readonly IGenericRepository<Producto> _productoRepository;
        private readonly IMapper _mapper;

        public ProductoController(IGenericRepository<Producto> productoRepository, IMapper mapper) 
        {
            _productoRepository = productoRepository;
            _mapper = mapper;
        }

        //http://localhost:20122/api/producto
        [HttpGet]
        public async Task<ActionResult<List<Producto>>> GetProductos(string sort, int? marca, int? categoria)
        {
            var spec = new ProductoWithCategoriaAndMarcaSpecification(sort, marca, categoria);

            var productos = await _productoRepository.GetAllWithSpec(spec);

            return Ok(_mapper.Map<IReadOnlyList<Producto>, IReadOnlyList<ProductoDto>>(productos));
        }

        //http://localhost:20122/api/producto/1
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductoDto>> GetProducto(int id) 
        {
            /* 
             spec = Debe incluir la lógica de la condición de la consulta y también las relaciones
             entre las entidades, entre Producto y Marca, Categoría. 
             */
            var spec = new ProductoWithCategoriaAndMarcaSpecification(id);
            var producto = await _productoRepository.GetByIdWithSpec(spec);

            if (producto == null)
            {
                return NotFound(new CodeErrorResponse(404, $"El producto de Id {id} no existe"));
            }

            return _mapper.Map<Producto,ProductoDto>(producto);
        }
    }
}
