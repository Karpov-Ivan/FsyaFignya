using System;

namespace GettingDataViaAPI.ApiHandler
{
    public interface IDogFactsApi
    {
        public Task<string> GetOneFactAboutDog();

        public Task<List<string>> GetSomeFactsAboutDogs();
    }
}