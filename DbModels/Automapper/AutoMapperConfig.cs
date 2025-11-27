using AutoMapper;
using DiabloModels.AutoMapper.Profiles;

namespace DiabloModels.AutoMapper
{
    public static class AutoMapperConfig
    {
        public static Mapper CreateMapGetMapperForErp()
        {
            return new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<MapperProfile>()));
        }

    }
}