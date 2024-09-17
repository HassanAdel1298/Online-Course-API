using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Online_Course_API.DTO
{
    public class QuestionDTO
    {
        public int Question_ID { get; set; }

        [Required(ErrorMessage = "Question text is required")]
        [StringLength(200, ErrorMessage = "Question text must be  200 characters")]
        public string Question_Text { get; set; }

        public int Quiz_ID { get; set; }
    }
}
