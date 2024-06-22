using GameShop.DataAccess.DataContext;
using GameShop.EntityLayer.Entities;
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
                throw new Exception("Category not found");
            }
            return category;
        }

        public void Create(Category category)
        {
            _context.Categories.Add(category);
            SaveChanges();
        }

        public void Update(int id, Category category)
        {
            var categoryToUpdate = _context.Categories.Find(id);
            if (categoryToUpdate == null)
            {
                throw new Exception("Category not found");
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
                throw new Exception("Category not found");
            }

            if(categoryToDelete.Games.Count() != 0)
            {
                throw new Exception("Category has games");
            }
            _context.Categories.Remove(categoryToDelete);
            SaveChanges();
        }
    }
}
