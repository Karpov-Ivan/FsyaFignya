using System;
using FsyaFignya.Common;
using System.Globalization;

namespace GettingDataViaAPI.ApiHandler
{
    //https://www.coindesk.com
    public class CoinDeskApi : ICoinDeskApi
    {
        private string url = "https://api.coindesk.com/v1/bpi/currentprice.json";

        public CoinDeskApi() { }

        public async Task<Double> GetThePriceOfBitcoin()
        {
            try
            {
                var dataJson = new RequestHandler().GetJson(this.url);

                NumberFormatInfo provider = new NumberFormatInfo();
                provider.NumberDecimalSeparator = ",";
                provider.NumberGroupSeparator = ".";

                var str = (await dataJson)["bpi"]["USD"]["rate"].ToString().Substring(0,
                          (await dataJson)["bpi"]["USD"]["rate"].ToString().IndexOf('.'));

                return Convert.ToDouble(str, provider);

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

        public async Task<string> GetRequestTime()
        {
            try
            {
                var dataJson = new RequestHandler().GetJson(this.url);

                return (await dataJson)["time"]["updated"].ToString();
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