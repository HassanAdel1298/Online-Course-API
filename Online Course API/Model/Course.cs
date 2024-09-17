 using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Course_API.Model
{
    public class Course
    {
        [Key]
        public int Course_ID { get; set; }

        [Required(ErrorMessage = "Course name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Course name must be between 3 and 50 characters")]
        public string Name { get; set; }

        [StringLength(500, ErrorMessage = "Description must at most 500 characters")]
        public string Description { get; set; }


        public int Duration { get; set; }


       

        [ForeignKey("Grade")]
        public int Grade_ID { get; set; }

        public virtual Grade Grade { get; set; }

        public virtual ICollection<Group> Groups { get; set; }

       

        public virtual ICollection<Instructor_Course> Instructor_Courses { get; set; }


    }
}
