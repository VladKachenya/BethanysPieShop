using System.Collections.Generic;
using BethanysPieShop.Interfaces.Factorys;
using BethanysPieShop.Interfaces.Services;
using BethanysPieShop.Models;
using BethanysPieShop.ViewModels;

namespace BethanysPieShop.Factorys
{
    public class PieViewModelFactory : IPieViewModelFactory
    {
        private readonly ICurrencyConverterService _currencyConverterService;

        public PieViewModelFactory(ICurrencyConverterService currencyConverterService)
        {
            _currencyConverterService = currencyConverterService;
        }
        public PieViewModel GetPieViewModel(Pie pie)
        {
            var res = new PieViewModel
            {
                PieId = pie.PieId,
                Name = pie.Name,
                Price = pie.Price,
                ShortDescription = pie.ShortDescription,
                ImageThumbnailUrl = pie.ImageThumbnailUrl,
                PriceInUSD = _currencyConverterService.ConvertBYNtoUSD(pie.Price),
                PriceInCryptocurrency = _currencyConverterService.ConvertBYNtoCryptocurrency(pie.Price, out string mark)
            };
            res.CryptocurrencyMarc = mark;
            return res;
        }

        public IEnumerable<PieViewModel> GetPieViewModels(IEnumerable<Pie> pies)
        {
            foreach (var pie in pies)
            {
                yield return GetPieViewModel(pie);
            }
        }

    }
}