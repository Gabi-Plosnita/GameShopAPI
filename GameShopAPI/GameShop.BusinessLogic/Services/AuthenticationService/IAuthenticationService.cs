using GameShop.EntityLayer.Entities;

namespace GameShop.BusinessLogic.Services
{
    public interface IAuthenticationService
    {
        string GenerateToken(User user);
    }
}
