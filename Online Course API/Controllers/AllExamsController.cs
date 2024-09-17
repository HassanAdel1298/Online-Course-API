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
    public class AllExamsController : ControllerBase
    {
        private readonly OnlineCourseDBContext _context;
        private readonly IMapper _mapper;

        public AllExamsController(OnlineCourseDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        [HttpGet("GroupOrstudent/{groupId}/{studentId}")]
        public ActionResult<IEnumerable<AllExamByGroupDTO>> GetExamsByGroupOrstudent(int groupId, int studentId)
        {
            try
            {
                var exams = _context.Quizzes
                .Where(g => g.Group_ID == groupId && g.Quiz_Available == true)
                .Include(q => q.Questions)
                .ToList();

                List<AllExamByGroupDTO> examsStudents = _context.Student_Quizzes
                .Include(q => q.Quiz).ThenInclude(q => q.Questions).
                Where(g => g.Quiz.Group_ID == groupId
                && g.Student_ID == studentId && g.Quiz.Quiz_Available == true).
                Select(g => new AllExamByGroupDTO
                {

                    Quiz_ID = g.Quiz_ID,
                    Quiz_Name = g.Quiz.Quiz_Name,
                    Grade = g.Grade,
                    Group_ID = g.Quiz.Group_ID,
                    numQuestion = g.Quiz.Questions.Count(),
                    Quiz_Available = g.Quiz.Quiz_Available,
                    Instructor_ID = g.Quiz.Instructor_ID


                }).ToList();

                List<AllExamByGroupDTO> AllExam = new List<AllExamByGroupDTO>();

                bool check;

                foreach (var exam in exams)
                {
                    check = true;

                    foreach (var examsStudent in examsStudents)
                    {
                        if (exam.Quiz_ID == examsStudent.Quiz_ID)
                        {
                            AllExam.Add(examsStudent);
                            check = false;
                        }
                    }

                    if (check)
                    {
                        AllExam.Add(new AllExamByGroupDTO()
                        {
                            Quiz_ID = exam.Quiz_ID,
                            Quiz_Name = exam.Quiz_Name,
                            Group_ID = exam.Group_ID,
                            Grade = -1,
                            numQuestion = exam.Questions.Count(),
                            Quiz_Available = exam.Quiz_Available,
                            Instructor_ID = exam.Instructor_ID

                        });
                    }


                }


                return Ok(AllExam);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }


        [HttpGet("Group/{groupId}")]
        public ActionResult<IEnumerable<AllExamByGroupDTO>> GetExamsByGroup(int groupId)
        {
            try
            {
                var exams = _context.Quizzes
                .Where(g => g.Group_ID == groupId).Include(q => q.Questions)
                .ToList();


                var allExamByGroupDTO = _mapper.Map<List<AllExamByGroupDTO>>(exams);

                return Ok(allExamByGroupDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
    }
}
