
using AutoMapper;
using BeerapiNet7._0.DTO;
using BeerapiNet7._0.Models;

namespace BeerapiNet7._0
{
    public class AutoMapperProfile : Profile
    {

        public AutoMapperProfile()
        {

            CreateMap<Beer, BeerDTO>();
            
            CreateMap<BeerDTO, Beer>();

            CreateMap<CountryDTO, Country>();

            CreateMap<TypeBeerDTO, TypeBeer>();

            CreateMap<CompanyDTO, Company>();
        }
    }
}
