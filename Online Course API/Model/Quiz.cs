using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Course_API.Model
{
    public class Quiz
    {
        [Key]
        public int Quiz_ID { get; set; }

        [Required(ErrorMessage = "Quiz name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Quiz name must be between 3 and 50 characters")]
        public string Quiz_Name { get; set; }


        [Required(ErrorMessage = "Quiz Available is required")]
        public bool Quiz_Available { get; set; }


        [ForeignKey("Instructor")]
        public int Instructor_ID { get; set; }

        public virtual Instructor Instructor { get; set; }


        [ForeignKey("Group")]
        public int Group_ID { get; set; }

        public virtual Group Group { get; set; }

        public virtual ICollection<Question> Questions { get; set; }

        public virtual ICollection<Student_Quiz> StudentQuizzes { get; set; }

    }
}
