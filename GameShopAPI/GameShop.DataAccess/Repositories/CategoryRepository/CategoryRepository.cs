using GameShop.DataAccess.DataContext;
using GameShop.EntityLayer.Entities;
using GameShop.EntityLayer.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace GameShop.DataAccess.Repositories
{
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        public CategoryRepository(GameShopDbContext context) : base(context) { }

        public List<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

        public Category GetById(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null)
            {
                throw new CategoryNotFoundException($"Category with ID {id} not found");
            }
            return category;
        }

        public void Create(Category category)
        {
            if(_context.Categories.Any(c => c.Name == category.Name))
            {
                throw new CategoryAlreadyExistsException($"Category with name {category.Name} already exists");
            }
            _context.Categories.Add(category);
            SaveChanges();
        }

        public void Update(int id, Category category)
        {
            var categoryToUpdate = _context.Categories.Find(id);
            if (categoryToUpdate == null)
            {
                throw new CategoryNotFoundException($"Category with ID {id} not found");
            }

            if (_context.Categories.Any(c => c.Name == category.Name && c.CategoryId != id))
            {
                throw new CategoryAlreadyExistsException($"Category with name {category.Name} already exists");
            }

            categoryToUpdate.Name = category.Name;
            SaveChanges();
        }

        public void Delete(int id)
        {
            var categoryToDelete = _context.Categories.Include(c => c.Games)
                                                      .FirstOrDefault(c => c.CategoryId == id);
            if (categoryToDelete == null)
            {
                throw new CategoryNotFoundException($"Category with ID {id} not found");
            }

            if (categoryToDelete.Games.Count() > 0)
            {
                throw new CategoryDeleteException($"Cannot delete category {categoryToDelete.Name} because it has games on the market");

            }

            _context.Categories.Remove(categoryToDelete);
            SaveChanges();
        }
    }
}
