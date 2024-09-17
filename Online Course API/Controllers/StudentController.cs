using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Online_Course_API.Data;
using Online_Course_API.DTO;
using Online_Course_API.Model;

namespace Online_Course_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class StudentController : ControllerBase
    {
        private readonly OnlineCourseDBContext _context;
        private readonly IMapper _mapper;

        public StudentController(OnlineCourseDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet]
        public ActionResult<IEnumerable<StudentDTO>> GetStudents()
        {
            try
            {
                var students = _context.Students.Include(s => s.Parent).ToList();
                var studentDTOs = _mapper.Map<List<StudentDTO>>(students);
                return Ok(studentDTOs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }


        [HttpGet("{id}")]
        public ActionResult<StudentDTO> GetStudent(int id)
        {
            var student = _context.Students.Include(s => s.Parent).FirstOrDefault(s => s.Student_ID == id);
            if (student == null)
            {
                return NotFound();
            }

            try
            {
                var studentDTO = _mapper.Map<StudentDTO>(student);
                return Ok(studentDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        [HttpGet("Group/{GroupID:int}")]
        public IActionResult GetByGradeID(int GroupID)
        {
            try
            {
                return Ok(_mapper.Map<IEnumerable<StudentDTO>>(
                    _context.Student_Groups
                        .Where(sg => sg.Group_ID == GroupID).
                        Select(sg => sg.Student)
                    ));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }



        //[Authorize(Roles = "Instructor")]
        [HttpPost]
        public IActionResult PostStudent(StudentDTO studentDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var student = _mapper.Map<Student>(studentDTO);

                _context.Students.Add(student);
                _context.SaveChanges();

                return CreatedAtAction(nameof(GetStudent), new { id = student.Student_ID }, studentDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }


        [HttpPut("{id}")]
        public IActionResult PutStudent(int id, StudentDTO studentDTO)
        {


            var student = _context.Students.Find(id);

            if (student == null)
            {
                return NotFound();
            }


            try
            {
                _mapper.Map(studentDTO, student);

                _context.SaveChanges();

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }


        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var student = _context.Students.Find(id);

            if (student == null)
            {
                return NotFound();
            }

            try
            {
                _context.Students.Remove(student);
                _context.SaveChanges();

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }


    }
}
