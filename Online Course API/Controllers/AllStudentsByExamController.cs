using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Online_Course_API.Data;
using Online_Course_API.DTO;

namespace Online_Course_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllStudentsByExamController : ControllerBase
    {

        private readonly OnlineCourseDBContext _context;
        private readonly IMapper _mapper;

        public AllStudentsByExamController(OnlineCourseDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("{QuizId}")]
        public ActionResult<IEnumerable<AllStudentsByExam>> AllStudents(int QuizId)
        {
            try
            {
                List<AllStudentsByExam> students = _context.Student_Quizzes
                .Include(s => s.Student).ThenInclude(s => s.ApplicationUser)
                .Include(q => q.Quiz).ThenInclude(q => q.Questions)
                .Where(q => q.Quiz_ID == QuizId)
                .Select(q => new AllStudentsByExam
                {
                    Quiz_ID = q.Quiz_ID,
                    Student_ID = q.Student_ID,
                    Grade = q.Grade,
                    numQuestion = q.Quiz.Questions.Count(),
                    StudentName = q.Student.ApplicationUser.Name,
                    UserName = q.Student.ApplicationUser.UserName,
                    Email = q.Student.ApplicationUser.Email

                })
                .ToList();

                return Ok(students);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }

}
