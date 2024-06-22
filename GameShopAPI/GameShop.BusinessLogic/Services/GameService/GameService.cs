using GameShop.BusinessLogic.Mapping;
using GameShop.DataAccess.Repositories;
using GameShop.EntityLayer.Dtos;
using GameShop.EntityLayer.Exceptions;

namespace GameShop.BusinessLogic.Services
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
            try
            {
                var game = _gameRepository.GetById(id);
                var gameResponseDto = game.ToGameResponseDto();
                return gameResponseDto;
            }
            catch (GameNotFoundException)
            {
                throw;
            }
        }

        public void Create(GameRequestDto gameDto)
        {
            try
            {
                var game = gameDto.ToGame();
                _gameRepository.Create(game);
            }
            catch (GameAlreadyExistsException)
            {
                throw;
            }
            catch (CategoryNotFoundException)
            {
                throw;
            }
            catch (GameCompanyNotFoundException)
            {
                throw;
            }
        }

        public void Update(int id, GameRequestDto updatedGameDto)
        {
            try
            {
                var game = updatedGameDto.ToGame();
                game.GameId = id;
                _gameRepository.Update(id, game);
            }
            catch (GameNotFoundException)
            {
                throw;
            }
            catch (CategoryNotFoundException)
            {
                throw;
            }
            catch (GameCompanyNotFoundException)
            {
                throw;
            }
        }

        public void Delete(int id)
        {
            try
            {
                _gameRepository.Delete(id);
            }
            catch (GameNotFoundException)
            {
                throw;
            }
        }
    }
}
