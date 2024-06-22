using GameShop.DataAccess.DataContext;
using GameShop.EntityLayer.Entities;
using GameShop.EntityLayer.Exceptions;
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
                throw new UserNotFoundException($"User with email {email} not found");
            }

            return user;
        }

        public User Get(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                throw new UserNotFoundException($"User with ID {id} not found");
            }

            return user;
        }

        public void Register(User user)
        {
            if (_context.Users.Any(u => u.Email == user.Email))
            {
                throw new UserAlreadyExistsException($"User with {user.Email} already exists");
            }
            _context.Add(user);
            SaveChanges();
        }

        public void Update(int id, User updatedUser)
        {
            var userToUpdate = _context.Users.Find(id);
            if (userToUpdate == null)
            {
                throw new UserNotFoundException($"User with ID {id} not found");
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
                throw new UserNotFoundException($"User with ID {id} not found");
            }
            _context.Users.Remove(userToDelete);
            SaveChanges();
        }
    }
}
