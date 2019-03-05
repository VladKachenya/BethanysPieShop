using System.Collections.Generic;
using BettanyPieShop.Models;

namespace BettanyPieShop.Interfaces.Models
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get; }
    }
}