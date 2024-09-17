using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Online_Course_API.DTO
{
    public class CourseDTO
    {
        public int Course_ID { get; set; }

        [Required(ErrorMessage = "Course name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Course name must be between 3 and 50 characters")]
        public string Name { get; set; }

        [StringLength(500, ErrorMessage = "Description must atmost 500 characters")]
        public string Description { get; set; }

        public int Duration { get; set; }

        public int Grade_ID { get; set; }
    }
}
