using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Course_API.Model
{
    public class Instructor_Course
    {
        [Key]
        [Column(Order = 0)]
        [ForeignKey("Instructor")]
        public int Instructor_ID { get; set; }

        public virtual Instructor Instructor { get; set; }


        [Key]
        [Column(Order = 1)]
        [ForeignKey("Course")]
        public int Course_ID { get; set; }

        public virtual Course Course { get; set; }

    }
}
