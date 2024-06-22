using GameShop.BusinessLogic.Mapping;
using GameShop.DataAccess.Repositories;
using GameShop.EntityLayer.Dtos;
using GameShop.EntityLayer.Exceptions;

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
            try
            {
                var role = _roleRepository.Get(id);
                var roleResponseDto = role.MapToRoleResponseDto();
                return roleResponseDto;
            }
            catch (RoleNotFoundException)
            {
                throw;
            }
        }

        public void Create(RoleRequestDto roleRequestDto)
        {
            try
            {
                var role = roleRequestDto.MapToRole();
                _roleRepository.Create(role);
            }
            catch (RoleAlreadyExistsException)
            {
                throw;
            }
        }

        public void Update(int id, RoleRequestDto updatedRoleRequestDto)
        {
            try
            {
                var updatedRole = updatedRoleRequestDto.MapToRole();
                _roleRepository.Update(id, updatedRole);
            }
            catch (RoleNotFoundException)
            {
                throw;
            }
        }

        public void Delete(int id)
        {
            try
            {
                _roleRepository.Delete(id);
            }
            catch (RoleNotFoundException)
            {
                throw;
            }
            catch (RoleDeleteException)
            {
                throw;
            }
        }
    }
}
