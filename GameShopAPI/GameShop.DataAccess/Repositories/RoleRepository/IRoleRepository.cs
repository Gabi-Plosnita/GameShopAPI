using GameShop.EntityLayer.Entities;

namespace GameShop.DataAccess.Repositories
{
    public interface IRoleRepository
    {
        List<Role> GetAll();

        Role Get(int id);

        void Create(Role role);

        void Update(int id, Role updatedRole);

        void Delete(int id);
    }
}
