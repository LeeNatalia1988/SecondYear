using AutoMapper;
using Notes.DTO;
using Notes.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Notes.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Note, NoteViewModel>().ReverseMap();
        }
    }
}
