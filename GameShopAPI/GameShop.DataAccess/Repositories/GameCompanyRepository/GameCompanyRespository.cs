using GameShop.DataAccess.DataContext;
using GameShop.EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameShop.DataAccess.Repositories.GameCompanyRepository
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
                throw new Exception("Game company not found");
            }
            return gameCompany;
        }

        public void Add(GameCompany gameCompany)
        {
            _context.GameCompanies.Add(gameCompany);
            SaveChanges();
        }

        public void Update(int id, GameCompany updatedGameCompany)
        {
            var gameCompany = _context.GameCompanies.Find(id);
            if(gameCompany == null) 
            {
                throw new Exception("Game company not found");
            }
            gameCompany.Name = updatedGameCompany.Name;
            gameCompany.Email = updatedGameCompany.Email;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var gameCompany = _context.GameCompanies.Include(gc => gc.Games)
                                                    .FirstOrDefault(gc => gc.GameCompanyId == id);
            if(gameCompany == null)
            {
                throw new Exception("Game company not found");
            }
            if(gameCompany.Games.Count > 0)
            {
                throw new Exception("Cannot delete game company with games");
            }

            _context.GameCompanies.Remove(gameCompany);
        }
    }
}
