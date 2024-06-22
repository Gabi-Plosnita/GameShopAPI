using GameShop.EntityLayer.Dtos;
using GameShop.EntityLayer.Entities;

namespace GameShop.BusinessLogic.Services
{
    public interface IRoleService
    {
        List<RoleResponseDto> GetAll();
        void Create(RoleRequestDto roleDto);
    }
}
