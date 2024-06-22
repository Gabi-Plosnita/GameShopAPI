using System.ComponentModel.DataAnnotations;

namespace GameShop.EntityLayer.Dtos
{
    public class GameRequestDto : IValidatableObject
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public int GameCompanyId { get; set; }

        public int CategoryId { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(Name))
            {
                yield return new ValidationResult("Name is required", new[] { nameof(Name) });
            }
            if(Price <= 0)
            {
                yield return new ValidationResult("Price must be greater than 0", new[] { nameof(Price) });
            }
            if(GameCompanyId <= 0)
            {
                yield return new ValidationResult("GameCompanyId must be greater than 0", new[] { nameof(GameCompanyId) });
            }
            if(CategoryId <= 0)
            {
                yield return new ValidationResult("CategoryId must be greater than 0", new[] { nameof(CategoryId) });
            }
        }
    }
}
