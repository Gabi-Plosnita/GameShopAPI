using GameShop.EntityLayer.Entities;

namespace GameShop.DataAccess.Repositories
{
    public interface IGameCompanyRepository
    {
        List<GameCompany> GetAll();

        GameCompany GetById(int id);

        void Add(GameCompany gameCompany);

        void Update(int id, GameCompany updatedGameCompany);

        void Delete(int id);
    }
}
