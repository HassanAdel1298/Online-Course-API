using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Online_Course_API.DTO
{
    public class SessionDTO
    {
        
        public int Session_ID { get; set; }

        [Required(ErrorMessage = "Session name is required")]
        [StringLength(100, ErrorMessage = "Session name must be between 3 and 100 characters", MinimumLength = 3)]
        public string SessionName { get; set; }

        [Required(ErrorMessage = "Start date is required")]
        [DataType(DataType.Date)]
        public DateTime Start_Date { get; set; }

        [Required(ErrorMessage = "End date is required")]
        [DataType(DataType.Date)]
        public DateTime End_at { get; set; }

        [Required(ErrorMessage = "Rate is required")]
        [Range(0, 5, ErrorMessage = "Rate must be positive number")]
        public float Rate { get; set; }

        public String OnlineVideo { get; set; }

        public String Zoom { get; set; }

        public int Instructor_ID { get; set; }

        public int Group_ID { get; set; }
    }
}
