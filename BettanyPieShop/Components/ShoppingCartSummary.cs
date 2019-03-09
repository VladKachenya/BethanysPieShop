using System.Collections.Generic;
using BettanyPieShop.Models;
using BettanyPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BettanyPieShop.Components
{
    public class ShoppingCartSummary : ViewComponent
    {
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartSummary(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        public IViewComponentResult Invoke()
        {
            //var items = _shoppingCart.GetShoppingCartItems();
            var items = new List<ShoppingCartItem>(){new ShoppingCartItem(), new ShoppingCartItem(), new ShoppingCartItem()};
            _shoppingCart.ShoppingCartItems = items;

            var shoppinCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            return View(shoppinCartViewModel);
        }
    }
}