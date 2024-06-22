using GameShop.BusinessLogic.Mapping;
using GameShop.DataAccess.Repositories;
using GameShop.EntityLayer.Dtos;
using GameShop.EntityLayer.Exceptions;

namespace GameShop.BusinessLogic.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public List<CategoryResponseDto> GetAll()
        {
            var categories = _categoryRepository.GetAll();
            var categoryResponseDtos = categories.ToListCategoryResponseDto();
            return categoryResponseDtos;
        }
        public CategoryResponseDto GetById(int id)
        {
            try
            { 
                var category = _categoryRepository.GetById(id);
                var categoryResponseDto = category.ToCategoryResponseDto();
                return categoryResponseDto;
            }
            catch (CategoryNotFoundException e)
            {
                throw;
            }
           
        }
        public void Create(CategoryRequestDto categoryDto)
        {
            var category = categoryDto.ToCategory();
            _categoryRepository.Create(category);
        }
        public void Update(int id, CategoryRequestDto updatedCategoryDto)
        {
            try
            {
                var category = updatedCategoryDto.ToCategory();
                category.CategoryId = id;
                _categoryRepository.Update(id, category);
            }
            catch (CategoryNotFoundException e)
            {
                throw;
            }
        }
        public void Delete(int id)
        {
            try
            {
                _categoryRepository.Delete(id);
            }
            catch (CategoryNotFoundException e)
            {
                throw;
            }
            catch (CategoryDeleteException e)
            {
                throw;
            }
        }
    }
}
