using GameShop.EntityLayer.Dtos;
using GameShop.EntityLayer.Entities;

namespace GameShop.BusinessLogic.Mapping
{
    public static class CategoryMappingExtensions
    {
        public static CategoryResponseDto ToCategoryResponseDto(this Category category)
        {
           var categoryResponseDto = new CategoryResponseDto
           {
               CategoryId = category.CategoryId,
               Name = category.Name
           };
           return categoryResponseDto;
        }

        public static Category ToCategory(this CategoryRequestDto categoryRequestDto)
        {
            var category = new Category
            {
                Name = categoryRequestDto.Name
            };  
            return category;
        }
    }
}
