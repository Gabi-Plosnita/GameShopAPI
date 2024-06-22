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

        public void Create(Role role)
        {
            if (_context.Roles.Any(r => r.Name == role.Name))
            {
                throw new Exception("Role already exists");
            }
            _context.Roles.Add(role);
            SaveChanges();
        }
    }
}
