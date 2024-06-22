using GameShop.BusinessLogic.Mapping;
using GameShop.DataAccess.Repositories;
using GameShop.EntityLayer.Dtos;

namespace GameShop.BusinessLogic.Services.RoleService
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public List<RoleResponseDto> GetAll()
        {
            var roles = _roleRepository.GetAll();
            var rolesDtos = roles.MapToRoleResponseDtos();
            return rolesDtos;
        }

        public void Create(RoleRequestDto roleDto)
        {
            var role = roleDto.MapToRole();
            _roleRepository.Create(role);
        }
    }
}
