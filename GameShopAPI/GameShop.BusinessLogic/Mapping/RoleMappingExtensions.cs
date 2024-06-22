using GameShop.EntityLayer.Dtos;
using GameShop.EntityLayer.Entities;

namespace GameShop.BusinessLogic.Mapping
{
    public static class RoleMappingExtensions
    {
        public static RoleResponseDto MapToRoleResponseDto(this Role role)
        {
            return new RoleResponseDto
            {
                Id = role.RoleId,
                Name = role.Name
            };
        }

        public static List<RoleResponseDto> MapToRoleResponseDtos(this List<Role> roles)
        {
            return roles.Select(role => role.MapToRoleResponseDto()).ToList();
        }

        public static Role MapToRole(this RoleRequestDto roleRequestDto)
        {
            return new Role
            {
                Name = roleRequestDto.Name
            };
        }
    }
}
