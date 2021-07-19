using AutoMapper;
using Core.Entities;

namespace WebApi.Dtos
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {
            CreateMap<Producto, ProductoDto>()
                .ForMember(pd => pd.CategoriaNombre, f => f.MapFrom(pr => pr.Categoria))
                .ForMember(pd => pd.MarcaNombre, f => f.MapFrom(pr => pr.Marca));
        }
    }
}
