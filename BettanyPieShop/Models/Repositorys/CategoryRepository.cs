using System.Collections.Generic;
using BettanyPieShop.Interfaces.Models;
using BettanyPieShop.Models.Contexts;

namespace BettanyPieShop.Models.Repositorys
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _appDbContext;

        public CategoryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Category> Categories => _appDbContext.Categories;
    }
}