using Online_Course_API.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Online_Course_API.DTO
{
    public class StudentQuizDTO
    {
      
        [Required(ErrorMessage = "Student ID is required")]
        public int Student_ID { get; set; }


        [Required(ErrorMessage = "Quiz ID is required")]
        public int Quiz_ID { get; set; }


        

        [Range(0, 100, ErrorMessage = "Grade must be between 0 and 100")]
        public float Grade { get; set; }
    }
}
