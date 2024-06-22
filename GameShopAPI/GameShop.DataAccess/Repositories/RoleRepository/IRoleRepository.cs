using GameShop.EntityLayer.Entities;

namespace GameShop.DataAccess.Repositories
{
    public interface IRoleRepository
    {
        List<Role> GetAll();
        void Create(Role role);
    }
}
