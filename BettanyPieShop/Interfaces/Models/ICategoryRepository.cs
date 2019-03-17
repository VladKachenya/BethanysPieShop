using System.Collections.Generic;
using BethanysPieShop.Models;

namespace BethanysPieShop.Interfaces.Models
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get; }
    }
}