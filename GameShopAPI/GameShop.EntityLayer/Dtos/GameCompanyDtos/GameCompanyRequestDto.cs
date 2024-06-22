using System.ComponentModel.DataAnnotations;

namespace GameShop.EntityLayer.Dtos
{
    public class GameCompanyRequestDto : IValidatableObject
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(Name))
            {
                yield return new ValidationResult("Name is required", new[] { nameof(Name) });
            }
            if (string.IsNullOrEmpty(Email)) 
            {
                yield return new ValidationResult("Email is required", new[] { nameof(Email) });
            }
        }
    }
}
