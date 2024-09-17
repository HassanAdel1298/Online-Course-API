using System.ComponentModel.DataAnnotations;

namespace Online_Course_API.DTO
{
    public class GradeDTO
    {
        public int Grade_ID { get; set; }

        [Required(ErrorMessage = "Grade name is required")]
        [StringLength(50, ErrorMessage = "Grade name must be between 3 and 50 characters", MinimumLength = 3)]
        public string Grade_Name { get; set; }

    }
}
