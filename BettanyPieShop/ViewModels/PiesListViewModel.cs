using System.Collections.Generic;
using BettanyPieShop.Models;

namespace BettanyPieShop.ViewModels
{
    public class PiesListViewModel
    {
        public IEnumerable<Pie> Pies { get; set; }
        public  string CurrentCategory { get; set; }
    }
}