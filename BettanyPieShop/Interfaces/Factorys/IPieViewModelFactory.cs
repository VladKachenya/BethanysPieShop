using BethanysPieShop.Models;
using BethanysPieShop.ViewModels;
using System.Collections.Generic;

namespace BethanysPieShop.Interfaces.Factorys
{
    public interface IPieViewModelFactory
    {
        PieViewModel GetPieViewModel(Pie pie);
        IEnumerable<PieViewModel> GetPieViewModels(IEnumerable<Pie> pies);
    }
}