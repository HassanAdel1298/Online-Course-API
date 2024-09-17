using System.ComponentModel.DataAnnotations;

namespace Online_Course_API.DTO
{
    public class AllStudentsByExam
    {

        public int Student_ID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 50 characters")]
        public string StudentName { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [MinLength(3, ErrorMessage = "Username must be at least 3 characters ")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        [RegularExpression(@"^.{3,}@gmail\.com$", ErrorMessage = "Email address must be from @gmail.com domain")]
        public string Email { get; set; }

        public int Quiz_ID { get; set; }

        [Range(0, 100, ErrorMessage = "Grade must be between 0 and 100")]
        public float Grade { get; set; }

        public int numQuestion { get; set; }



    }
}
