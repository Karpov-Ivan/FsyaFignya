using System;
using FsyaFignya.Common;

namespace GettingDataViaAPI.ApiHandler
{
    //https://agify.io/
    public class AgeByNameApi : IAgeByNameApi
    {
        private string urlForGettingAgeByName = "https://api.agify.io/?name=";

        private string urlForGettingAgeByNameAndCountry = "&country_id=";

        public AgeByNameApi() { }

        public async Task<int> GetTheAgeByName(string name = "ivan")
        {
            try
            {
                var dataJson = new RequestHandler().GetJson(this.urlForGettingAgeByName + name);

                return Convert.ToInt32((await dataJson)["age"].ToString());
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

        public async Task<int> GetAgeByNameAndCountry(string name = "ivan", string countryId = "RU")
        {
            try
            {
                var dataJson = new RequestHandler().GetJson(this.urlForGettingAgeByName + name +
                                                            this.urlForGettingAgeByNameAndCountry + countryId);

                return Convert.ToInt32((await dataJson)["age"].ToString());
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