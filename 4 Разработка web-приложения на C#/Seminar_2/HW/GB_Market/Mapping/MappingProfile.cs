using AutoMapper;
using GB_Market.DTO;
using GB_Market.Models;

namespace GB_Market.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductViewModel>().ReverseMap();
            CreateMap<ProductGroup, ProductGroupViewModel>().ReverseMap();
        }
    }
}
