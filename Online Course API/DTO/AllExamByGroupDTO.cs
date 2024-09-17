using System.ComponentModel.DataAnnotations;

namespace Online_Course_API.DTO
{
    public class AllExamByGroupDTO
    {
        public int Quiz_ID { get; set; }
        public string Quiz_Name { get; set; }

        [Required(ErrorMessage = "Quiz Available is required")]
        public bool Quiz_Available { get; set; }

        public float Grade { get; set; }

        public int numQuestion { get; set; }

        public int Group_ID { get; set; }

        public int Instructor_ID { get; set; }


    }
}
