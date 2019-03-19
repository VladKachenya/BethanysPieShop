using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethanysPieShop.Hubs;
using BethanysPieShop.Interfaces.Models;
using BethanysPieShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace BethanysPieShop.ControllersApi
{
    [Route("api/[controller]")]
    public class ShoppingCartOperationController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ShoppingCart _shoppingCart;
        private readonly IHubContext<ShoppingCartHub> _shoppingCartHubContext;

        public ShoppingCartOperationController(IPieRepository pieRepository,
            ShoppingCart shoppingCart, IHubContext<ShoppingCartHub> shoppingCartHubContext)
        {
            _pieRepository = pieRepository;
            _shoppingCart = shoppingCart;
            _shoppingCartHubContext = shoppingCartHubContext;
        }

        [HttpPut("{pieId}")]
        public IActionResult Put(int pieId)
        {
            var selectedPie = _pieRepository.Pies.FirstOrDefault(p => p.PieId == pieId);
            if (selectedPie != null)
            {
                _shoppingCart.AddToCart(selectedPie, 1);
                NotifyClients();
            }

            return Ok(pieId);
        }

        [HttpDelete("{pieId}")]
        public IActionResult Delete(int pieId)
        {
            var selectedPie = _pieRepository.Pies.FirstOrDefault(p => p.PieId == pieId);

            if (selectedPie != null)
            {
                _shoppingCart.RemoveFromCart(selectedPie);
                NotifyClients();
            }

            return Ok(pieId);
        }

        private async void NotifyClients()
        {
            int count = _shoppingCart.GetShoppingCartItems().Count;
            await _shoppingCartHubContext.Clients.All.SendAsync("RefreshShopingCart", count.ToString());
        }
    }
}