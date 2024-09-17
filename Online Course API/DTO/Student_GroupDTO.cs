using Online_Course_API.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Online_Course_API.DTO
{
    public class Student_GroupDTO
    {

        [Required(ErrorMessage = "Student ID is required")]
        public int Student_ID { get; set; }


        [Required(ErrorMessage = "Group ID is required")]
        public int Group_ID { get; set; }


        public DateTime Enroll_Date { get; set; }

    }
}
