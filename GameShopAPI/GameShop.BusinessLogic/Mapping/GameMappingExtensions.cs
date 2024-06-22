using GameShop.EntityLayer.Dtos;
using GameShop.EntityLayer.Entities;

namespace GameShop.BusinessLogic.Mapping
{
    public static class GameMappingExtensions
    {
        public static GameResponseDto ToGameResponseDto(this Game game)
        {
            var result = new GameResponseDto
            {
                GameId = game.GameId,
                Name = game.Name,
                Price = game.Price,
                GameCompanyName = game.GameCompany.Name,
                CategoryName = game.Category.Name
            };
            return result;
        }

        public static Game ToGame(this GameRequestDto gameRequestDto)
        {
            var result = new Game
            {
                Name = gameRequestDto.Name,
                Price = gameRequestDto.Price,
                GameCompanyId = gameRequestDto.GameCompanyId,
                CategoryId = gameRequestDto.CategoryId
            };
            return result;
        }

        public static List<GameResponseDto> ToGameResponseDtos(this List<Game> games)
        {
            var result = new List<GameResponseDto>();
            foreach (var game in games)
            {
                result.Add(game.ToGameResponseDto());
            }
            return result;
        }
    }
}
