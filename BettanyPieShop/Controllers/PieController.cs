﻿using System.Collections.Generic;
using System.Linq;
using BethanysPieShop.Interfaces.Factorys;
using BethanysPieShop.Interfaces.Models;
using BethanysPieShop.Models;
using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Controllers
{
    public class PieController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IPieRepository _pieRepository;
        private readonly IPieViewModelFactory _pieViewModelFactory;

        public PieController(ICategoryRepository categoryRepository, IPieRepository pieRepository, IPieViewModelFactory pieViewModelFactory)
        {
            _categoryRepository = categoryRepository;
            _pieRepository = pieRepository;
            _pieViewModelFactory = pieViewModelFactory;
        }

        public ViewResult List(string category)
        {
            IEnumerable<Pie> pies;
            string currentCategory = string.Empty;

            if (string.IsNullOrEmpty(category))
            {
                pies = _pieRepository.Pies.OrderBy(p => p.PieId);
                currentCategory = "All pies";
            }
            else
            {
                pies = _pieRepository.Pies.Where(p => p.Category.CategoryName == category)
                    .OrderBy(p => p.PieId);
                currentCategory = _categoryRepository.Categories.FirstOrDefault(c => c.CategoryName == category)
                    .CategoryName;
            }

            return View(new PiesListViewModel
            {
                Pies = _pieViewModelFactory.GetPieViewModels(pies),
                CurrentCategory = currentCategory
            });
        }

        public IActionResult Details(int id)
        {
            var pie = _pieRepository.GetPieById(id);
            if (pie == null)
                return NotFound();

            return View(_pieViewModelFactory.GetPieViewModel(pie));
        }
    }
}