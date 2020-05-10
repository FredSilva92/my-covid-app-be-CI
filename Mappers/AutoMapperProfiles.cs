using AutoMapper;
using MyCovidApp_core.Models;

namespace MyCovidApp_core.Mappers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() {
            CreateMap<ISOFIPSData, Occurence>();
                /*.ForMember(dest => dest.IsoData.Iso2, 
                    opt => opt.MapFrom(origin => origin.Iso2))
                .ForMember(dest => dest.IsoData.Iso3, 
                    opt => opt.MapFrom(origin => origin.Iso3))
                .ForMember(dest => dest.IsoData.Continent, 
                    opt => opt.MapFrom(origin => origin.Continent))
                .ForMember(dest => dest.IsoData.CountryName, 
                    opt => opt.MapFrom(origin => origin.Continent));*/
        }
    }
}