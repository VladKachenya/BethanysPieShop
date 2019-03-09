using System.Collections.Generic;
using BettanyPieShop.Models;

namespace BettanyPieShop.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Pie> PiesOfTheWeek { get; set; }
    }
}