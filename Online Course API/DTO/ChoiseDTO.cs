using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Online_Course_API.DTO
{
    public class ChoiseDTO
    {

        public int Choise_ID { get; set; }


        [Required(ErrorMessage = "Text is required")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Text must be between 1 and 100 characters")]
        public string Text { get; set; }


        public bool IsCorrect { get; set; }

        [Required(ErrorMessage = "Question ID is required")]
        public int Question_ID { get; set; }


    }
}
