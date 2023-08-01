using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FsyaFignya.Models.Models;
using System.Collections.Generic;

namespace FsyaFignya.Interfaces.Repository
{
    public interface IRepository
    {
        public Task<List<_AgeByNameOrCountry>> GetListAgeByNameOrCountry();

        public Task AddAgeByNameOrCountry(_AgeByNameOrCountry ageByNameOrCountry);

        public Task<List<_CountryNato>> GetListOfCountryNato();

        public Task AddListOfCountryNato(List<_CountryNato> listOfCountryNato);

        public Task<List<_FactsAboutDogs>> GetListFactsAboutDogs();

        public Task AddFactsAboutDogs(List<_FactsAboutDogs> factsAboutDogs);

        public Task DeleteFactsAboutDogs();

        public Task<List<_InformationAboutBitcoin>> GetListInformationAboutBitcoin();

        public Task AddInformationAboutBitcoin(_InformationAboutBitcoin informationAboutBitcoin);

        public Task<List<_ListOfSeriesTitlesOfTheBigBangTheory>> GetListOfSeriesTitlesOfTheBigBangTheory();

        public Task AddListOfSeriesTitlesOfTheBigBangTheory(List<_ListOfSeriesTitlesOfTheBigBangTheory> listOfSeriesTitlesOfTheBigBangTheory);
    }
}