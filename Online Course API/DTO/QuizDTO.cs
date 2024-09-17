using Online_Course_API.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Online_Course_API.DTO
{
    public class QuizDTO
    {
        public int Quiz_ID { get; set; }

        [Required(ErrorMessage = "Quiz name is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Quiz name must be between 3 and 50 characters")]
        public string Quiz_Name { get; set; }

        [Required(ErrorMessage = "Quiz Available is required")]
        public bool Quiz_Available { get; set; }

        public int Instructor_ID { get; set; }

        public int Group_ID { get; set; }
    }
}
