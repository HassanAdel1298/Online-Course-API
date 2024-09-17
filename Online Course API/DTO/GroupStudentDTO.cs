using System.ComponentModel.DataAnnotations;

namespace Online_Course_API.DTO
{
    public class GroupStudentDTO
    {

        [Required(ErrorMessage = "Student ID is required")]
        public int Student_ID { get; set; }


        [Required(ErrorMessage = "Group ID is required")]
        public int Group_ID { get; set; }

    }
}
