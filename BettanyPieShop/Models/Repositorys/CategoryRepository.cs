using System.Collections.Generic;
using BethanysPieShop.Interfaces.Models;
using BethanysPieShop.Models.Contexts;

namespace BethanysPieShop.Models.Repositorys
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