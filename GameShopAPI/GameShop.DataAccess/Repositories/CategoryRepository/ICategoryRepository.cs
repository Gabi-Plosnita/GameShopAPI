using GameShop.EntityLayer.Entities;

namespace GameShop.DataAccess.Repositories
{
    public interface ICategoryRepository
    {
        List<Category> GetAll();
        Category GetById(int id);
        void Create(Category category);
        void Update(int id, Category updatedCategory);
        void Delete(int id);
    }
}
