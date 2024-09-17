using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Course_API.Model
{
    public class Question
    {
        [Key]
        public int Question_ID { get; set; }

        [Required(ErrorMessage = "Question text is required")]
        [StringLength(200, ErrorMessage = "Question text must at most 200 characters")]
        public string Question_Text { get; set; }

        [ForeignKey("Quiz")]
        public int Quiz_ID { get; set; }

        public virtual Quiz Quiz { get; set; }

        public virtual ICollection<Choise> Choises { get; set; }

        public virtual ICollection<Student_Question> StudentQuestions { get; set; }

    }
}
