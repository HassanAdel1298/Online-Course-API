using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Online_Course_API.Model
{
    public class ApplicationUser : IdentityUser
    {
        //public ICollection<Instructor> Instructors { get; set; }
        //public ICollection<Student> Students { get; set; }

        [RegularExpression("^(Male|Female)$", ErrorMessage = "Invalid gender")]
        public string? Gender { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 50 characters")]
        public string Name { get; set; }


    }
}
