using System.ComponentModel.DataAnnotations;
using static Online_Course_API.Controllers.AccountController;

namespace Online_Course_API.DTO
{
    public class RegisterUserDto
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [MinLength(3, ErrorMessage = "Username must be at least 3 characters ")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^.{6,20}$", ErrorMessage = "Password must be between 6 and 20 characters")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm password is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "password and confirmation password not matched ")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        [RegularExpression(@"^.{3,}@gmail\.com$", ErrorMessage = "Email address must be from @gmail.com domain")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Role is required")]
        [RegularExpression("^(Instructor|Student)$", ErrorMessage = "Invalid Role")]
        public string Role { get; set; }
    }
}
