
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

            
            CreateMap<Country, CountryDTO>();
            CreateMap<CountryDTO, Country>();


            CreateMap<TypeBeer, TypeBeerDTO>();
            CreateMap<TypeBeerDTO, TypeBeer>();

            CreateMap<Company, CompanyDTO>();
            CreateMap<CompanyDTO, Company>();
        }
    }
}
