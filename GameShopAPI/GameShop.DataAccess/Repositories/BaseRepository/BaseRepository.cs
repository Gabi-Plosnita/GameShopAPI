using GameShop.DataAccess.DataContext;

namespace GameShop.DataAccess.Repositories
{
    public class BaseRepository
    {
        protected readonly GameShopDbContext _context;

        public BaseRepository(GameShopDbContext context)
        {
            _context = context;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
