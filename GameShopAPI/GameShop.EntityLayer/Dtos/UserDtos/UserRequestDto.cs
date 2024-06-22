using System.ComponentModel.DataAnnotations;

namespace GameShop.EntityLayer.Dtos
{
    public class UserRequestDto : IValidatableObject
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int RoleId { get; set; }    

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

            if (string.IsNullOrEmpty(Password))
            {
                yield return new ValidationResult("Password is required", new[] { nameof(Password) });
            }

            if(RoleId <= 0)
            {
                yield return new ValidationResult("RoleId must be greater than 0", new[] { nameof(RoleId) });
            }
        }

    }
}
