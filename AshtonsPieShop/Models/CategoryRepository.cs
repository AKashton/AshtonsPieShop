
namespace AshtonsPieShop.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AshtonsPieShopDbContext _ashtonsPieShopDbContext;

        public CategoryRepository(AshtonsPieShopDbContext ashtonsPieShopDbContext)
        {
            _ashtonsPieShopDbContext = ashtonsPieShopDbContext;
        }

        public IEnumerable<Category> AllCategories => _ashtonsPieShopDbContext.Categories.OrderBy(p => p.CategoryName);
    }
}