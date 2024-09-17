using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Online_Course_API.Model
{
    public class Student_Group
    {
        [Key]
        [Column(Order = 0)]
        [ForeignKey("Student")]
        public int Student_ID { get; set; }

        public virtual Student Student { get; set; }


        [Key]
        [Column(Order = 1)]
        [ForeignKey("Group")]
        public int Group_ID { get; set; }

        public virtual Group Group { get; set; }

        public DateTime Enroll_Date { get; set; }
    }
}
