using GameShop.DataAccess.DataContext;
using GameShop.EntityLayer.Entities;
using GameShop.EntityLayer.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace GameShop.DataAccess.Repositories
{
    public class RoleRepository: BaseRepository, IRoleRepository
    {
        public RoleRepository(GameShopDbContext context): base(context)
        {
        }

        public List<Role> GetAll()
        {
            return _context.Roles.ToList();
        }

        public Role Get(int id) 
        {
            var role = _context.Roles.Find(id);
            if (role == null)
            {
                throw new RoleNotFoundException($"Role with ID {id} not found");
            }

            return role;
        }

        public void Create(Role role)
        {
            if (_context.Roles.Any(r => r.Name == role.Name))
            {
                throw new RoleAlreadyExistsException($"Role {role} already exists");
            }

            _context.Roles.Add(role);
            SaveChanges();
        }

        public void Update(int id, Role updatedRole)
        {
            var roleToUpdate = _context.Roles.Find(id);
            if (roleToUpdate == null)
            {
                throw new RoleNotFoundException($"Role with ID {id} not found");
            }

            if (_context.Roles.Any(r => r.Name == updatedRole.Name && r.RoleId != id))
            {
                throw new RoleAlreadyExistsException($"Role {updatedRole} already exists");
            }

            roleToUpdate.Name = updatedRole.Name;
            SaveChanges();
        }

        public void Delete(int id)
        {
            var roleToDelete = _context.Roles.Include(r => r.Users)
                                             .FirstOrDefault(r => r.RoleId == id);
            if (roleToDelete == null)
            {
                throw new RoleNotFoundException($"Role with ID {id} not found");
            }

            if (roleToDelete.Users.Count() > 0)
            {
                throw new RoleDeleteException($"Role with ID {id} has users");
            }

            _context.Roles.Remove(roleToDelete);
            SaveChanges();
        }
    }
}
