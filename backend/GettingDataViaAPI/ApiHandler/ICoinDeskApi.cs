using System;

namespace GettingDataViaAPI.ApiHandler
{
    public interface ICoinDeskApi
    {
        public Task<Double> GetThePriceOfBitcoin();

        public Task<string> GetRequestTime();
    }
}

