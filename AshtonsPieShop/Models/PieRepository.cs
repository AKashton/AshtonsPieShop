
using Microsoft.EntityFrameworkCore;

namespace AshtonsPieShop.Models
{
    public class PieRepository : IPieRepository
    {
        private readonly AshtonsPieShopDbContext _ashtonsPieShopDbContext;

        public PieRepository(AshtonsPieShopDbContext ashtonsPieShopDbContext)
        {
            _ashtonsPieShopDbContext = ashtonsPieShopDbContext;
        }

        public IEnumerable<Pie> AllPies
        {
            get
            {
                return _ashtonsPieShopDbContext.Pies.Include(c=> c.Category);
            }
        }
        public IEnumerable<Pie> PiesOfTheWeek
        {
            get
            {
                return _ashtonsPieShopDbContext.Pies.Include(c => c.Category).Where(p => p.IsPieOfTheWeek);
            }
        }

        public Pie? GetPieById(int pieid)
        {
            return _ashtonsPieShopDbContext.Pies.FirstOrDefault(p => p.PieId == pieid);
        }
    }

}
