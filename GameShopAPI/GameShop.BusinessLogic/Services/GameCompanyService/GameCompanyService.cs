using GameShop.BusinessLogic.Mapping;
using GameShop.DataAccess.Repositories;
using GameShop.EntityLayer.Dtos;
using GameShop.EntityLayer.Exceptions;

namespace GameShop.BusinessLogic.Services
{
    public class GameCompanyService : IGameCompanyService
    {
        private readonly IGameCompanyRepository _gameCompanyRepository;
        public GameCompanyService(IGameCompanyRepository gameCompanyRepository)
        {
            _gameCompanyRepository = gameCompanyRepository;
        }

        public List<GameCompanyResponseDto> GetAll()
        {
            var gameCompanies = _gameCompanyRepository.GetAll();
            var gameCompanyResponseDtos = gameCompanies.ToListGameCompanyResponseDto();
            return gameCompanyResponseDtos;
        }

        public GameCompanyResponseDto GetById(int id)
        {
            try
            {
                var gameCompany = _gameCompanyRepository.GetById(id);
                var gameCompanyResponseDto = gameCompany.ToGameCompanyResponseDto();
                return gameCompanyResponseDto;
            }
            catch (GameCompanyNotFoundException)
            {
                throw;
            }
        }

        public void Create(GameCompanyRequestDto gameCompanyDto)
        {
            var gameCompany = gameCompanyDto.ToGameCompany();
            _gameCompanyRepository.Create(gameCompany);
        }

        public void Update(int id, GameCompanyRequestDto updatedGameCompanyDto)
        {
            try
            {
                var gameCompany = updatedGameCompanyDto.ToGameCompany();
                gameCompany.GameCompanyId = id;
                _gameCompanyRepository.Update(id, gameCompany);
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
                _gameCompanyRepository.Delete(id);
            }
            catch (GameCompanyNotFoundException)
            {
                throw;
            }
            catch (CompanyDeleteException)
            {
                throw;
            }
        }
    }
}
