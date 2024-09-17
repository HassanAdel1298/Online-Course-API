using System.ComponentModel.DataAnnotations;

namespace Online_Course_API.DTO
{
    public class InstructorGroupsDTO
    {
        public int Course_ID { get; set; }


        [Required(ErrorMessage = "Course name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Course name must be between 3 and 50 characters")]
        public string Course_Name { get; set; }

        public int Grade_ID { get; set; }

        [Required(ErrorMessage = "Grade name is required")]
        [StringLength(50, ErrorMessage = "Grade name must be between 3 and 50 characters", MinimumLength = 3)]
        public string Grade_Name { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0, 1000, ErrorMessage = "Price must be a positive number")]

        public float Price { get; set; }

        public int Group_ID { get; set; }

        [Required(ErrorMessage = "Group name is required")]
        [StringLength(50, ErrorMessage = "Group name must be between 3 and 50 characters", MinimumLength = 3)]
        public string GroupName { get; set; }

        [Required(ErrorMessage = "Number of students is required")]
        [Range(0, 22, ErrorMessage = "Number of students must be at least 0")]
        public int Num_Students { get; set; }

        [Required(ErrorMessage = "Creation date is required")]
        [DataType(DataType.Date)]
        public DateOnly Creation_Date { get; set; }

        [Required(ErrorMessage = "End date is required")]
        [DataType(DataType.Date)]
        public DateOnly End_Date { get; set; }




    }
}
