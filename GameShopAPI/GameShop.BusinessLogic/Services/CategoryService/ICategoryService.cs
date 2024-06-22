using GameShop.EntityLayer.Dtos;
using GameShop.EntityLayer.Entities;

namespace GameShop.BusinessLogic.Services
{
    public interface ICategoryService
    {
        List<CategoryResponseDto> GetAll();

        CategoryResponseDto GetById(int id);

        void Create(CategoryRequestDto category);

        void Update(int id, CategoryRequestDto category);

        void Delete(int id);
    }
}
