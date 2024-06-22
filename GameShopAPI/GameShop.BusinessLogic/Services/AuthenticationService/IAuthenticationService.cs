using GameShop.EntityLayer.Entities;

namespace GameShop.BusinessLogic.Services.AuthenticationService
{
    public interface IAuthenticationService
    {
        string GenerateToken(User user);
    }
}
