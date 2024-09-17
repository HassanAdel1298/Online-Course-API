using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Online_Course_API.Model
{
    public class Student_Session
    {
        [Key]
        [Column(Order = 0)]
        [ForeignKey("Student")]
        public int Student_ID { get; set; }

    
        public virtual Student Student { get; set; }


        [Key]
        [Column(Order = 1)]
        [ForeignKey("Session")]
        [Required(ErrorMessage = "Session ID is required")]
        public int Session_ID { get; set; }

      
        public virtual Session Session { get; set; }

        [Range(0, 5, ErrorMessage = "Rate must be between 0 and 5")]
        public float Rate { get; set; }

        [StringLength(200, ErrorMessage = "Comment length must be at most 200 characters")]
        public string Comment { get; set; }


    }
}
