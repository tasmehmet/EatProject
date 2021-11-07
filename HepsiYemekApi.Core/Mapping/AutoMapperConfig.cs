using AutoMapper;

namespace HepsiYemekApi.Core.Mapping
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DtoToEntityMappingProfile());
                cfg.AddProfile(new DtoToModelMappingProfile());
            });
        }
    }
}