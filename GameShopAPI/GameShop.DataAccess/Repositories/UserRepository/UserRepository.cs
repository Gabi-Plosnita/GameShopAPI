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
            var user = _context.Users
                               .Where(u => u.UserId == id)
                               .Include(u => u.Role)
                               .FirstOrDefault();
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

            var role = _context.Roles.Find(user.RoleId);
            if (role == null)
            {
                throw new RoleNotFoundException($"Role with ID {user.RoleId} not found");
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

            var role = _context.Roles.Find(updatedUser.RoleId);
            if (role == null)
            {
                throw new RoleNotFoundException($"Role with ID {updatedUser.RoleId} not found");
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
