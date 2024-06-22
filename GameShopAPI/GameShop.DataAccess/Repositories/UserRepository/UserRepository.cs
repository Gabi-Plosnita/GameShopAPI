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

        public User GetByEmail(string email)
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

        public User Get(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            return user;
        }

        public void Register(User user)
        {
            if (_context.Users.Any(u => u.Email == user.Email))
            {
                throw new Exception("User already exists");
            }
            _context.Add(user);
            SaveChanges();
        }

        public void Update(int id, User updatedUser)
        {
            var userToUpdate = _context.Users.Find(id);
            if (userToUpdate == null)
            {
                throw new Exception("User not found");
            }
            userToUpdate.Email = updatedUser.Email;
            userToUpdate.Password = updatedUser.Password;
            userToUpdate.RoleId = updatedUser.RoleId;
            SaveChanges();
        }

        public void Delete(int id)
        {
            var userToDelete = _context.Users.Find(id);
            if (userToDelete == null)
            {
                throw new Exception("User not found");
            }
            _context.Users.Remove(userToDelete);
            SaveChanges();
        }
    }
}
