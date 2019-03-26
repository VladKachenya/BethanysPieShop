using System.Collections.Generic;
using BethanysPieShop.Models;

namespace BethanysPieShop.ViewModels
{
    public class PiesListViewModel
    {
        public IEnumerable<PieViewModel> Pies { get; set; }
        public  string CurrentCategory { get; set; }
    }
}