using System;
using FsyaFignya.Common;

namespace GettingDataViaAPI.ApiHandler
{
    //https://dogapi.dog/
    public class DogFactsApi : IDogFactsApi
    {
        private string urlForOneDog = "https://dogapi.dog/api/facts?number=1";

        private string urlForMultipleDogs = "https://dogapi.dog/api/facts?number=5";

        public DogFactsApi() { }

        public async Task<string> GetOneFactAboutDog()
        {
            try
            {
                var dataJson = await new RequestHandler().GetJson(this.urlForOneDog);

                return dataJson["facts"].ToString();
            }
            catch (HttpRequestException exception)
            {
                throw exception;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public async Task<List<string>> GetSomeFactsAboutDogs()
        {
            try
            {
                var dataJson = await new RequestHandler().GetJson(this.urlForMultipleDogs);

                return dataJson["facts"].Select(x => x.ToString()).ToList();
            }
            catch (HttpRequestException exception)
            {
                throw exception;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}