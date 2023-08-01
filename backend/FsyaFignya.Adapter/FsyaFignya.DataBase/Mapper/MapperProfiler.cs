using System;
using AutoMapper;
using FsyaFignya.Models.Models;
using FsyaFignya.DataBase.Models.Models;

namespace FsyaFignya.DataBase.Mapper
{
    public class MappingDatabaseProfile : Profile
    {
        public MappingDatabaseProfile()
        {
            CreateMap<AgeByNameOrCountry, _AgeByNameOrCountry>().ReverseMap();
            CreateMap<CountryNato, _CountryNato>().ReverseMap();
            CreateMap<FactsAboutDogs, _FactsAboutDogs>().ReverseMap();
            CreateMap<InformationAboutBitcoin, _InformationAboutBitcoin>().ReverseMap();
            CreateMap<ListOfSeriesTitlesOfTheBigBangTheory, _ListOfSeriesTitlesOfTheBigBangTheory>().ReverseMap();
        }
    }
}

