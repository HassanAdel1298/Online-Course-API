using Online_Course_API.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Online_Course_API.DTO
{
    public class Student_SessionDTO
    {
        [Required(ErrorMessage = "Student ID is required")]
        public int Student_ID { get; set; }


        
        [Required(ErrorMessage = "Session ID is required")]
        public int Session_ID { get; set; }


        [Range(0, 5, ErrorMessage = "Rate must be between 0 and 5")]
        public float Rate { get; set; }

        [StringLength(200, ErrorMessage = "Comment length Must be at most 200 characters")]
        public string Comment { get; set; }

    }
}
