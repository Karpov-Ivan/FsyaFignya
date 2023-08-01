using System;

namespace GettingDataViaAPI.ApiHandler
{
    public interface IAgeByNameApi
    {
        public Task<int> GetTheAgeByName(string name = "ivan");

        public Task<int> GetAgeByNameAndCountry(string name = "ivan", string countryId = "RU");
    }
}

