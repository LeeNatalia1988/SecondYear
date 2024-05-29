using UserWorker.AuthorizationModels;
using UserWorker.DTO;
using AutoMapper;
using UserWorker.DbModels;

namespace UserWorker.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        { 
            CreateMap<UserModel, UserViewModel>().ReverseMap();
            CreateMap<UserViewModel, UserViewModelWithoutPassword>().ReverseMap();
            CreateMap<User, UserViewModelWithoutPassword>().ReverseMap();
        }
    }
}
