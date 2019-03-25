using BethanysPieShop.Helpers;
using BethanysPieShop.Interfaces.Services;
using System;
using System.Net;
using System.Threading;
using System.Web;

namespace BethanysPieShop.Services
{
    public class CoinMarketCapService : ICoinMarketCapService
    {
        private Timer _timer;

        public decimal BitcoinPriceInUsd { get; protected set; }
        public string Sumbol { get; protected set; }

        public CoinMarketCapService()
        {
            TimerCallback tm = new TimerCallback(Initialization);
            _timer = new Timer(tm, null, 0, TimeSpan.TicksPerMinute);
        }


        #region reqest Area
        protected void Initialization(object obj)
        {
            var str = MakeAPICall();
            var welcome = CoinMarketCapRequestEntity.FromJson(str);
            BitcoinPriceInUsd = welcome.Data[0].Quote.Usd.Price;
            Sumbol = welcome.Data[0].Symbol;

        }

        private static string API_KEY = "f4a53eee-0d1e-4091-9b90-96a461c9a3f8";

        private string MakeAPICall()
        {
            var URL = new UriBuilder("https://pro-api.coinmarketcap.com/v1/cryptocurrency/listings/latest");

            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["start"] = "1";
            queryString["limit"] = "1";
            queryString["convert"] = "USD";

            URL.Query = queryString.ToString();

            var client = new WebClient();
            client.Headers.Add("X-CMC_PRO_API_KEY", API_KEY);
            client.Headers.Add("Accepts", "application/json");
            return client.DownloadString(URL.ToString());

        }
        #endregion


    }
}