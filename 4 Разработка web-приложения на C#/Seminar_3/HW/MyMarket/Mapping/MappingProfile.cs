using AutoMapper;
using MyMarket.DTO;
using MyMarket.Models;

namespace MyMarket.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductViewModel>().ReverseMap();
            
            CreateMap<ProductGroup, ProductGroupViewModel>().ReverseMap();
            
            CreateMap<Storage, StorageViewModel>().ReverseMap();
            
        }
    }
}
