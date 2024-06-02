using MessageWorker.DTO;
using AutoMapper;
using MessageWorker.DbModels;

namespace MessageWorker.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Message, MessageViewModelToSend>().ReverseMap();
            CreateMap<Message, MessageViewModel>().ReverseMap();
            CreateMap<Message, MessageViewModelToReceive>().ReverseMap();
        }
    }
}
