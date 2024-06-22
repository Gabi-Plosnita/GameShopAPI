using GameShop.EntityLayer.Entities;

namespace GameShop.DataAccess.Repositories
{
    public interface ICategoryRepository
    {
        List<Category> GetAll();
        Category GetById(int id);
        void Create(Category category);
        void Update(int id, Category category);
        void Delete(int id);
    }
}
