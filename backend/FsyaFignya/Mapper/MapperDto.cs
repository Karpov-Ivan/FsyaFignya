using System;
using AutoMapper;
using FsyaFignya.Dto;
using FsyaFignya.Models.Models;

namespace FsyaFignya.Mapper
{
    public class MapperDto : Profile
    {
        public MapperDto()
        {
            CreateMap<_AgeByNameOrCountry, AgeByNameOrCountryDto>().ReverseMap();

            CreateMap<_CountryNato, CountryNatoDto>().ReverseMap();

            CreateMap<_FactsAboutDogs, FactsAboutDogsDto>().ReverseMap();

            CreateMap<_InformationAboutBitcoin, InformationAboutBitcoinDto>().ReverseMap();

            CreateMap<_ListOfSeriesTitlesOfTheBigBangTheory, ListOfSeriesTitlesOfTheBigBangTheoryDto>().ReverseMap();
        }
    }
}