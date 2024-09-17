using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Online_Course_API.Model
{
    public class Student_Question
    {
        [Key]
        [Column(Order = 0)]
        [ForeignKey("Student")]
        public int Student_ID { get; set; }

        public virtual Student Student { get; set; }


        [Key]
        [Column(Order = 1)]
        [ForeignKey("Question")]
        [Required(ErrorMessage = "Question ID is required")]
        public int Question_ID { get; set; }

       
        public virtual Question Question { get; set; }


        public string St_Answer { get; set; }
    }
}
