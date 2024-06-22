using GameShop.EntityLayer.Dtos;
using GameShop.EntityLayer.Entities;

namespace GameShop.BusinessLogic.Services
{
    public interface IGameCompanyService
    {
        List<GameCompanyResponseDto> GetAll();

        GameCompanyResponseDto GetById(int id);

        void Create(GameCompanyRequestDto gameCompany);

        void Update(int id, GameCompanyRequestDto updatedGameCompany);

        void Delete(int id);
    }
}
