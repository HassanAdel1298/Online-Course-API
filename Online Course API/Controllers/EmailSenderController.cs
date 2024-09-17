using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Online_Course_API.Data;
using System.Net.Mail;
using System.Net;
using System.Text;
using Online_Course_API.sendEmail;
using Online_Course_API.Model;


namespace Online_Course_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailSenderController : ControllerBase
    {
        private readonly IEmailSender emailSender;
        private readonly OnlineCourseDBContext context;

        public EmailSenderController(OnlineCourseDBContext _context, IEmailSender _emailSender)
        {
            context = _context;
            emailSender = _emailSender;
        }


        [HttpGet("{GroupId:int}")]
        public ActionResult SendEmail(int GroupId)
        {

            try
            {
                Group group = context.Groups.Find(GroupId);



                Instructor instructor = context.Instructors.Find(group.Instructor_ID);

                ApplicationUser user = context.Users.Find(instructor.UserId);


                if (group != null && instructor != null && user != null)
                {
                    //user.Email
                    emailSender.SendEmail(user.Email
                        , $"New Student is now Enrolled in {group.GroupName}," +
                        $" Number of Student : {group.Num_Students}");
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Error sending email: " + ex.Message);
            }

        }




    }
}
