using System;
using BethanysPieShop.Interfaces.Services;

namespace BethanysPieShop.Services
{
    public class CurrencyConverterService : ICurrencyConverterService
    {
        private readonly INationalBankOfRepublicBelarusServise _bankOfRepublicBelarusServise;
        private readonly ICoinMarketCapService _coinMarketCapService;

        public CurrencyConverterService(INationalBankOfRepublicBelarusServise bankOfRepublicBelarusServise, ICoinMarketCapService coinMarketCapService)
        {
            _bankOfRepublicBelarusServise = bankOfRepublicBelarusServise;
            _coinMarketCapService = coinMarketCapService;
        }
        public decimal ConvertBYNtoUSD(decimal BYN)
        {
            return BYN / _bankOfRepublicBelarusServise.USDinBYN;
        }

        public decimal ConvertBYNtoCryptocurrency(decimal BYN, out string cryptocurrencyMark)
        {
            cryptocurrencyMark = _coinMarketCapService.Sumbol;
            return Decimal.Round(ConvertBYNtoUSD(BYN) / _coinMarketCapService.BitcoinPriceInUsd, 8);
        }
    }
}