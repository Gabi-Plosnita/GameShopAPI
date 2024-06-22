using GameShop.EntityLayer.Dtos;
using GameShop.EntityLayer.Entities;

namespace GameShop.BusinessLogic.Mapping
{
    public static class GameCompanyMappingExtensions
    {
        public static GameCompanyResponseDto ToGameCompanyResponseDto(this GameCompany gameCompany)
        {
            var gameCompanyResponseDto = new GameCompanyResponseDto
            {
                GameCompanyId = gameCompany.GameCompanyId,
                Name = gameCompany.Name,
                Email = gameCompany.Email
            };
            return gameCompanyResponseDto;
        }   

        public static GameCompany ToGameCompany(this GameCompanyRequestDto gameCompanyRequestDto)
        {
            var gameCompany = new GameCompany
            {
                Name = gameCompanyRequestDto.Name,
                Email = gameCompanyRequestDto.Email
            };
            return gameCompany;
        }

        public static List<GameCompanyResponseDto> ToListGameCompanyResponseDto(this List<GameCompany> gameCompanies)
        {
            var gameCompanyResponseDtos = new List<GameCompanyResponseDto>();
            foreach (var gameCompany in gameCompanies)
            {
                gameCompanyResponseDtos.Add(gameCompany.ToGameCompanyResponseDto());
            }
            return gameCompanyResponseDtos;
        }
    }
}
