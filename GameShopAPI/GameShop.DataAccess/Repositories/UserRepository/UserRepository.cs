using GameShop.DataAccess.DataContext;
using GameShop.EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameShop.DataAccess.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(GameShopDbContext gameShopDbContext) : base(gameShopDbContext)
        {
        }

        public List<User> GetAll()
        {
            var users = _context.Users
                                .Include(u => u.Role)
                                .ToList();
            return users;
        }

        public User GetUserByEmail(string email)
        {
            var user = _context.Users
                               .Where(u => u.Email == email)
                               .Include(u => u.Role)
                               .FirstOrDefault();
            if (user == null)
            {
                throw new Exception("User not found");
            }

            return user;
        }

        public void RegisterUser(User user)
        {
            if (_context.Users.Any(u => u.Email == user.Email))
            {
                throw new Exception("User already exists");
            }
            _context.Add(user);
            SaveChanges();
        }
    }
}
