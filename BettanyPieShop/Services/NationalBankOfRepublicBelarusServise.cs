using System;
using System.Net;
using System.Web;
using BethanysPieShop.Helpers;
using BethanysPieShop.Interfaces.Services;
using BethanysPieShop.Services.Base;
using Newtonsoft.Json;

namespace BethanysPieShop.Services
{
    public class NationalBankOfRepublicBelarusServise : ExternalApiBase, INationalBankOfRepublicBelarusServise
    {
        #region implementation of INationalBankOfRepublicBelarusServise
        public decimal USDinBYN { get; protected set; }
        #endregion

        #region override of ExternalApiBase

        public NationalBankOfRepublicBelarusServise()
            : base(null, TimeSpan.TicksPerMinute) {}

        protected override void Initialization(object obj)
        {
            var URL = new UriBuilder("http://www.nbrb.by/API/ExRates/Rates/USD");
            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["ParamMode"] = "2";

            URL.Query = queryString.ToString();
            var client = new WebClient();
            var str = client.DownloadString(URL.ToString());
            USDinBYN = NationalBankOfRepublicBelarusRequestEntity.FromJson(str).CurOfficialRate;
        }


        #endregion

    }
}