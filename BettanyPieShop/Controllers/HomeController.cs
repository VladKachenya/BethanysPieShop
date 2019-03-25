using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethanysPieShop.Interfaces.Models;
using BethanysPieShop.Interfaces.Services;
using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICoinMarketCapService _coinMarketCapService;

        public HomeController(IPieRepository pieRepository, ICoinMarketCapService coinMarketCapService)
        {
            _pieRepository = pieRepository;
            _coinMarketCapService = coinMarketCapService;
        }

        // GET: Home
        public ActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                PiesOfTheWeek = _pieRepository.PiesOfTheWeek
            };

            return View(homeViewModel);
        }
    }
}