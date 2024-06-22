using GameShop.DataAccess.DataContext;

namespace GameShop.DataAccess.Repositories
{
    public class BaseRepository
    {
        private readonly GameShopDbContext _context;

        public BaseRepository(GameShopDbContext context)
        {
            _context = context;
        }
    }
}
