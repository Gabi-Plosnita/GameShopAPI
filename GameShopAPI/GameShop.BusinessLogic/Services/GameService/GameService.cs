using GameShop.BusinessLogic.Mapping;
using GameShop.DataAccess.Repositories;
using GameShop.EntityLayer.Dtos;

namespace GameShop.BusinessLogic.Services.GameService
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;

        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public List<GameResponseDto> GetAll()
        {
            var games = _gameRepository.GetAll();
            var gameResponseDtos = games.ToGameResponseDtos();
            return gameResponseDtos;
        }

        public GameResponseDto GetById(int id)
        {
            var game = _gameRepository.GetById(id);
            var gameResponseDto = game.ToGameResponseDto();
            return gameResponseDto;
        }

        public void Create(GameRequestDto gameDto)
        {
            var game = gameDto.ToGame();
            _gameRepository.Add(game);
        }

        public void Update(int id, GameRequestDto updatedGameDto)
        {
            var game = updatedGameDto.ToGame();
            game.GameId = id;
            _gameRepository.Update(id, game);
        }

        public void Delete(int id)
        {
            _gameRepository.Delete(id);
        }
    }
}
