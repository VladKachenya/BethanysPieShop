using BettanyPieShop.Interfaces.Models;
using BettanyPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BettanyPieShop.Controllers
{
    public class PieController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IPieRepository _pieRepository;

        public PieController(ICategoryRepository categoryRepository, IPieRepository pieRepository)
        {
            _categoryRepository = categoryRepository;
            _pieRepository = pieRepository;
        }

        public ViewResult List()
        {
            var pies = new PiesListViewModel()
                { Pies = _pieRepository.Pies, CurrentCategory = "Cheese cakes"};
            return View(pies);
        }
    }
}