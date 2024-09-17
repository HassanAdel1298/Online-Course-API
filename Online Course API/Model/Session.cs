using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Course_API.Model
{
    public class Session
    {
        [Key]
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
        [Range(0, 5, ErrorMessage = "Rate must be a positive number")]
        public float Rate { get; set; }

        public String OnlineVideo { get; set; }

        public String Zoom {  get; set; }

        [ForeignKey("Instructor")]
        public int? Instructor_ID { get; set; }

        public virtual Instructor Instructor { get; set; }


        [ForeignKey("Group")]
        public int Group_ID { get; set; }

        public virtual Group Group { get; set; }

        public virtual ICollection<Student_Session> StudentSessions { get; set; }

    }
}
