using GameShop.BusinessLogic.Mapping;
using GameShop.DataAccess.Repositories;
using GameShop.EntityLayer.Dtos;
using GameShop.EntityLayer.Exceptions;

namespace GameShop.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthenticationService _authenticationService;

        public UserService(IUserRepository userRepository, IAuthenticationService authenticationService)
        {
            _userRepository = userRepository;
            _authenticationService = authenticationService;
        }

        public void Register(UserRequestDto userRequestDto)
        {
            try
            {
                string passwordHash = BCrypt.Net.BCrypt.HashPassword(userRequestDto.Password);
                userRequestDto.Password = passwordHash;
                var user = userRequestDto.MapToUser();
                _userRepository.Register(user);

            }
            catch (UserAlreadyExistsException)
            {
                throw;
            }
            catch (RoleNotFoundException)
            {
                throw;
            }
        }
        public UserResponseDto GetByEmail(string email)
        {
            try
            {
                var user = _userRepository.GetByEmail(email);
                var userResponseDto = user.MapToUserResponseDto();
                return userResponseDto;
            }
            catch (UserNotFoundException)
            {
                throw;
            }
        }

        public string Login(LoginRequestDto loginDto)
        {
            try
            {
                var user = _userRepository.GetByEmail(loginDto.Email);

                if (!BCrypt.Net.BCrypt.Verify(loginDto.Password, user.Password))
                {
                    throw new Exception("Invalid password");
                }

                string token = _authenticationService.GenerateToken(user);
                return token;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<UserResponseDto> GetAll()
        {
            var users = _userRepository.GetAll();
            var userResponseDtos = users.MapToUserResponseDtos();
            return userResponseDtos;
        }

        public UserResponseDto Get(int id)
        {
            try
            {
                var user = _userRepository.Get(id);
                var userResponseDto = user.MapToUserResponseDto();
                return userResponseDto;
            }
            catch (UserNotFoundException)
            {
                throw;
            }
        }

        public void Update(int id, UserRequestDto updatedUserDto)
        {
            try
            {
                var updatedUserEntity = updatedUserDto.MapToUser();
                _userRepository.Update(id, updatedUserEntity);
            }
            catch (UserNotFoundException)
            {
                throw;
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
                _userRepository.Delete(id);
            }
            catch (UserNotFoundException)
            {
                throw;
            }
        }
    }
}
