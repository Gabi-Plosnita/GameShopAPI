using GameShop.DataAccess.DataContext;
using GameShop.EntityLayer.Entities;

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
            return _context.Categories.Find(id);
        }

        public void Create(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void Update(int id, Category category)
        {
            var categoryToUpdate = _context.Categories.Find(id);
            categoryToUpdate.Name = category.Name;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var categoryToDelete = _context.Categories.Find(id);
            _context.Categories.Remove(categoryToDelete);
            _context.SaveChanges();
        }
    }
}
