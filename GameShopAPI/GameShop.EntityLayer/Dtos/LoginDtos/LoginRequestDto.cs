using System.ComponentModel.DataAnnotations;

namespace GameShop.EntityLayer.Dtos
{
    public class LoginRequestDto : IValidatableObject
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(string.IsNullOrEmpty(Email))
            {
                yield return new ValidationResult("Email is required", new[] { nameof(Email) });
            }
            if(string.IsNullOrEmpty(Password)) 
            {
                yield return new ValidationResult("Password is required", new[] { nameof(Password) });
            }
        }
    }
}
