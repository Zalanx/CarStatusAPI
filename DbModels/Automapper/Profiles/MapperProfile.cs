using AutoMapper;
using CarStatusAPI.ApiModels;
using CarStatusAPI.DbModels;
using CarStatusAPI.Models;


namespace DiabloModels.AutoMapper.Profiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {

            CreateMap<DbTicket, TicketDto>().ReverseMap();
            CreateMap<DbUser, UserDto>().ReverseMap();
            CreateMap<DbTicketnumber, Ticketnumber>().ReverseMap();
            CreateMap<DbToDos, ToDoDto>().ReverseMap();


        }
    }
}
