using GameShop.DataAccess.DataContext;
using GameShop.EntityLayer.Entities;

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
                throw new Exception("Role not found");
            }
            return role;
        }

        public void Create(Role role)
        {
            if (_context.Roles.Any(r => r.Name == role.Name))
            {
                throw new Exception("Role already exists");
            }
            _context.Roles.Add(role);
            SaveChanges();
        }

        public void Update(int id, Role updatedRole)
        {
            var roleToUpdate = _context.Roles.Find(id);
            if (roleToUpdate == null)
            {
                throw new Exception("Role not found");
            }
            roleToUpdate.Name = updatedRole.Name;
            SaveChanges();
        }

        public void Delete(int id)
        {
            var roleToDelete = _context.Roles.Find(id);
            if (roleToDelete == null)
            {
                throw new Exception("Role not found");
            }
            _context.Roles.Remove(roleToDelete);
            SaveChanges();
        }
    }
}
