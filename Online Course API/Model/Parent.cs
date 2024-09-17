using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Course_API.Model
{
    public class Parent
    {
        [Key]
        public int Parent_ID { get; set; }


        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }



        //[Required(ErrorMessage = "First name is required")]
        //[StringLength(50, MinimumLength = 2, ErrorMessage = "First name must be between 2 and 50 characters")]
        //public string First_Name { get; set; }

        //[Required(ErrorMessage = "Last name is required")]
        //[StringLength(50, MinimumLength = 2, ErrorMessage = "Last name must be between 2 and 50 characters")]
        //public string Last_Name { get; set; }

        //[RegularExpression(@"^01\d{9}$", ErrorMessage = "Phone number must start with 01 and be 11 digits ")]
        //public string Phone { get; set; }

        //[Required(ErrorMessage = "Email is required")]
        //[EmailAddress(ErrorMessage = "Invalid email address")]
        //[RegularExpression(@"^\w+@gmail\.com$", ErrorMessage = "Email address must be from @gmail.com domain")]
        //public string Email { get; set; }

        //[Required(ErrorMessage = "Password is required")]
        //[RegularExpression(@"^.{6,20}$", ErrorMessage = "Password must be between 6 and 20 characters ")]
        //[DataType(DataType.Password)]
        //public string Password { get; set; }

        //[Required(ErrorMessage = "Gender is required")]
        //[RegularExpression("^(Male|Female)$", ErrorMessage = "Invalid gender")]
        //public string Gender { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
