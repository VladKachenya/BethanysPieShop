using BethanysPieShop.Interfaces.Models;
using BethanysPieShop.Interfaces.Services;
using BethanysPieShop.Models;
using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using BethanysPieShop.Interfaces.Factorys;

namespace BethanysPieShop.ControllersApi
{
    [Route("api/[controller]")]
    public class PieDataController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICurrencyConverterService _converterService;
        private readonly IPieViewModelFactory _pieViewModelFactory;

        public PieDataController(IPieRepository pieRepository, ICurrencyConverterService converterService, IPieViewModelFactory pieViewModelFactory)
        {
            _pieRepository = pieRepository;
            _converterService = converterService;
            _pieViewModelFactory = pieViewModelFactory;
        }

        [HttpGet]
        public IEnumerable<PieViewModel> LoadMorePies()
        {
            IEnumerable<Pie> dbPies = null;

            dbPies = _pieRepository.Pies.OrderBy(p => p.PieId).Take(5);

            return _pieViewModelFactory.GetPieViewModels(dbPies);
        }
    }
}