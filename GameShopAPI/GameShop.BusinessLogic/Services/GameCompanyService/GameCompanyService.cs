using GameShop.BusinessLogic.Mapping;
using GameShop.DataAccess.Repositories;
using GameShop.EntityLayer.Dtos;

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
            var gameCompany = _gameCompanyRepository.GetById(id);
            var gameCompanyResponseDto = gameCompany.ToGameCompanyResponseDto();
            return gameCompanyResponseDto;
        }

        public void Create(GameCompanyRequestDto gameCompanyDto)
        {
            var gameCompany = gameCompanyDto.ToGameCompany();
            _gameCompanyRepository.Create(gameCompany);
        }

        public void Update(int id, GameCompanyRequestDto updatedGameCompanyDto)
        {
            var gameCompany = updatedGameCompanyDto.ToGameCompany();
            gameCompany.GameCompanyId = id;
            _gameCompanyRepository.Update(id, gameCompany);
        }
        public void Delete(int id) 
        {
            _gameCompanyRepository.Delete(id);
        }
    }
}
