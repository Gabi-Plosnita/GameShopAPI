using System.ComponentModel.DataAnnotations;

namespace GameShop.EntityLayer.Dtos
{
    public class CategoryRequestDto : IValidatableObject
    {
        public string Name { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(Name))
            {
                yield return new ValidationResult("Name is required", new[] { nameof(Name) });
            }
        }
    }
}
