using System.Collections.Generic;
using BethanysPieShop.Models;

namespace BethanysPieShop.Interfaces.Models
{
    public interface IPieRepository
    {
        IEnumerable<Pie> Pies { get; }
        IEnumerable<Pie> PiesOfTheWeek { get; }
        Pie GetPieById(int pieId);
    }
}