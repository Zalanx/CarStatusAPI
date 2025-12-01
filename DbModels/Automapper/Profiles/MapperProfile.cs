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

            CreateMap<DbTicket, Ticket>().ReverseMap();
            CreateMap<DbUser, User>().ReverseMap();
            CreateMap<DbTicketnumber, Ticketnumber>().ReverseMap();

        }
    }
}
