using GameShop.EntityLayer.Dtos;
using GameShop.EntityLayer.Entities;

namespace GameShop.BusinessLogic.Mapping
{
    public static class UserMappingExtensions
    {
        public static User MapToUser(this UserRequestDto userRequestDto)
        {
            return new User
            {
                Username = userRequestDto.Name,
                Email = userRequestDto.Email,
                Password = userRequestDto.Password,
                RoleId = userRequestDto.RoleId
            };
        }

        public static UserResponseDto MapToUserResponseDto(this User user)
        {
            return new UserResponseDto
            {
                Id = user.UserId,
                Name = user.Username,
                Email = user.Email,
                Role = user.Role.Name
            };
        }

        public static List<UserResponseDto> MapToUserResponseDtos(this List<User> users)
        {
            return users.Select(user => user.MapToUserResponseDto()).ToList();
        }
    }
}
