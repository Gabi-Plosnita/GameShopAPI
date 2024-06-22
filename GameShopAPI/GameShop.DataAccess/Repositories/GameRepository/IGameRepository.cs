using GameShop.EntityLayer.Entities;

namespace GameShop.DataAccess.Repositories
{
    public interface IGameRepository
    {
        List<Game> GetAll();

        Game GetById(int id);

        void Add(Game game);

        void Update(int id, Game updatedGame);

        void Delete(int id);
    }
}
