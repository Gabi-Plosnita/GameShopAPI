using GameShop.BusinessLogic.Mapping;
using GameShop.DataAccess.Repositories;
using GameShop.EntityLayer.Dtos;

namespace GameShop.BusinessLogic.Services
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
            var roleResponseDtos = roles.MapToRoleResponseDtos();
            return roleResponseDtos;
        }

        public RoleResponseDto Get(int id)
        {
            var role = _roleRepository.Get(id);
            var roleResponseDto = role.MapToRoleResponseDto();
            return roleResponseDto;
        }

        public void Create(RoleRequestDto roleRequestDto)
        {
            var role = roleRequestDto.MapToRole();
            _roleRepository.Create(role);
        }

        public void Update(int id, RoleRequestDto updatedRoleRequestDto)
        {
            var updatedRole = updatedRoleRequestDto.MapToRole();
            _roleRepository.Update(id, updatedRole);
        }

        public void Delete(int id)
        {
            _roleRepository.Delete(id);
        }
    }
}
