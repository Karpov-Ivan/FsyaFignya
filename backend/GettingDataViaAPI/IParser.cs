using System;

namespace GettingDataViaAPI
{
    public interface IParser
    {
        public Task<List<string>> GetListOfSeriesTitlesOfTheBigBangTheory();

        public Task<List<string[]>> GetListOfNameCountryNato();
    }
}