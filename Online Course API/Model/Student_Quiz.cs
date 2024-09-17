using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Online_Course_API.Model
{
    public class Student_Quiz
    {
        [Key]
        [Column(Order = 0)]
        [ForeignKey("Student")]
        [Required(ErrorMessage = "Student ID is required")]
        public int Student_ID { get; set; }

      
        public virtual Student Student { get; set; }


        [Key]
        [Column(Order = 1)]
        [ForeignKey("Quiz")]
        [Required(ErrorMessage = "Quiz ID is required")]
        public int Quiz_ID { get; set; }

       
        public virtual Quiz Quiz { get; set; }

        [Range(0, 100, ErrorMessage = "Grade must be between 0 and 100")]
        public float Grade { get; set; }
    }
}
