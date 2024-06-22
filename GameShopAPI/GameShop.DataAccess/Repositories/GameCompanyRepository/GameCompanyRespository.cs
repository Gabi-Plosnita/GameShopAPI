using GameShop.DataAccess.DataContext;
using GameShop.EntityLayer.Entities;
using GameShop.EntityLayer.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace GameShop.DataAccess.Repositories
{
    public class GameCompanyRespository : BaseRepository, IGameCompanyRepository
    {
        public GameCompanyRespository(GameShopDbContext context) : base(context)
        {
        }

        public List<GameCompany> GetAll()
        {
            return _context.GameCompanies.ToList();
        }

        public GameCompany GetById(int id)
        {
            var gameCompany = _context.GameCompanies.Find(id);
            if(gameCompany == null)
            {
                throw new GameCompanyNotFoundException($"Game company with ID {id} not found");
            }
            return gameCompany;
        }

        public void Create(GameCompany gameCompany)
        {
            _context.GameCompanies.Add(gameCompany);
            SaveChanges();
        }

        public void Update(int id, GameCompany updatedGameCompany)
        {
            var gameCompany = _context.GameCompanies.Find(id);
            if(gameCompany == null) 
            {
                throw new GameCompanyNotFoundException($"Game company with ID {id} not found");
            }
            gameCompany.Name = updatedGameCompany.Name;
            gameCompany.Email = updatedGameCompany.Email;
            SaveChanges();
        }

        public void Delete(int id)
        {
            var gameCompany = _context.GameCompanies.Include(gc => gc.Games)
                                                    .FirstOrDefault(gc => gc.GameCompanyId == id);
            if(gameCompany == null)
            {
                throw new GameCompanyNotFoundException($"Game company with ID {id} not found");
            }
            if (gameCompany.Games.Count > 0)
            {
                throw new CompanyDeleteException($"Cannot delete game company {gameCompany.Name} because it has games on the market");
            }

            _context.GameCompanies.Remove(gameCompany);
            SaveChanges();
        }
    }
}
