using AutoMapper;
using Entities;

namespace WebApi.Dtos
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {
            CreateMap<Product, ProductDto>()
                .ForMember(pd => pd.CategoryName, f => f.MapFrom(pr => pr.Category.Name))
                .ForMember(pd => pd.MarkName, f => f.MapFrom(pr => pr.Mark.Name));
        }
    }
}