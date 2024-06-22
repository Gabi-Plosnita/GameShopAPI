using GameShop.EntityLayer.Entities;

namespace GameShop.DataAccess.Repositories
{
    public interface IUserRepository
    {
        void Register(User user);

        User GetByEmail(string email);

        List<User> GetAll();

        User Get(int id);

        void Update(int id, User updatedUser);

        void Delete(int id);
    }
}
