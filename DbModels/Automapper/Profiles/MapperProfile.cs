using AutoMapper;
using CarStatusAPI.ApiModels;
using CarStatusAPI.Models;

namespace CarStatusAPI.DbModels.Automapper.Profiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {

            CreateMap<DbTicket, TicketDto>().ReverseMap();
            CreateMap<DbUser, UserDto>().ReverseMap();
            CreateMap<DbTicketnumber, Ticketnumber>().ReverseMap();
            CreateMap<DbToDos, ToDoDto>()
                .ForMember(d => d.Task, o => o.MapFrom(s => s.Todo))
                .ReverseMap()
                .ForMember(d => d.Todo, o => o.MapFrom(s => s.Task));


        }
    }
}
