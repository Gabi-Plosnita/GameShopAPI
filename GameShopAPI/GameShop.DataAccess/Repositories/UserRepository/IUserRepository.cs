using GameShop.EntityLayer.Entities;

namespace GameShop.DataAccess.Repositories
{
    public interface IUserRepository
    {
        void RegisterUser(User user);
        User GetUserByEmail(string email);
        List<User> GetAll();
    }
}
