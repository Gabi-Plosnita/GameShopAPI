using GameShop.DataAccess.DataContext;
using GameShop.EntityLayer.Entities;
using GameShop.EntityLayer.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace GameShop.DataAccess.Repositories
{
    public class GameRepository : BaseRepository, IGameRepository
    {
        public GameRepository(GameShopDbContext context) : base(context)
        {
        }

        public List<Game> GetAll()
        {
            var games = _context.Games.Include(g => g.GameCompany)
                                      .Include(g => g.Category)
                                      .ToList();
            return games;
        }

        public Game GetById(int id)
        {
            var game = _context.Games.Include(g => g.GameCompany)
                                     .Include(g => g.Category)
                                     .FirstOrDefault(g => g.GameId == id);
            if(game == null)
            {
                throw new GameNotFoundException($"Game with ID {id} not found");
            }
            return game;
        }

        public void Create(Game game)
        {
            _context.Games.Add(game);
            SaveChanges();
        }

        public void Update(int id, Game updatedGame)
        {
            var game = _context.Games.Find(id);
            if(game == null) 
            {
                throw new GameNotFoundException($"Game with ID {id} not found");
            }
            game.Name = updatedGame.Name;
            game.Price = updatedGame.Price;
            SaveChanges();
        }

        public void Delete(int id)
        {
            var game = _context.Games.Find(id);
            if(game == null)
            {
                throw new GameNotFoundException($"Game with ID {id} not found");
            }
            _context.Games.Remove(game);
            SaveChanges();
        }
    }
}
