using AutoMapper;
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
    public class StudentGroupsController : ControllerBase
    {
        private readonly OnlineCourseDBContext _context;
        private readonly IMapper _mapper;


        public StudentGroupsController(OnlineCourseDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student_GroupDTO>>> GetStudentGroups()
        {
            var studentGroups = await _context.Student_Groups.ToListAsync();
            return _mapper.Map<List<Student_GroupDTO>>(studentGroups);
        }

        [HttpGet("{studentId}/{groupId}")]
        public async Task<ActionResult<Student_GroupDTO>> GetStudentGroup(int studentId, int groupId)
        {
            var studentGroup = await _context.Student_Groups.FindAsync(studentId, groupId);

            if (studentGroup == null)
            {
                return NotFound();
            }

            return _mapper.Map<Student_GroupDTO>(studentGroup);
        }


        [HttpPost]
        public async Task<ActionResult<Student_GroupDTO>> PostStudentGroup(Student_GroupDTO studentGroupDTO)
        {
            var studentGroup = _mapper.Map<Student_Group>(studentGroupDTO);
            _context.Student_Groups.Add(studentGroup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudentGroups", new { id = studentGroup.Student_ID }, studentGroupDTO);
        }


        [HttpPut("{studentId}/{groupId}")]
        public async Task<IActionResult> PutStudentGroup(int studentId, int groupId, Student_GroupDTO studentGroupDTO)
        {


            var existingStudentGroup = await _context.Student_Groups.FindAsync(studentId, groupId);
            if (existingStudentGroup == null)
            {
                return NotFound();
            }

            _mapper.Map(studentGroupDTO, existingStudentGroup);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        ///
        [HttpGet("hasnotThisGroup/{studentId}")]
        public ActionResult<IEnumerable<GroupDTO>> GetGroupsexceptThisStudentID(int studentId)
        {
            var groups = _context.Groups
                .Where(g => !_context.Student_Groups.Any(sg => sg.Group_ID == g.Group_ID && sg.Student_ID == studentId))
                .ToList();

            var groupDTOs = _mapper.Map<IEnumerable<GroupDTO>>(groups);

            return Ok(groupDTOs);
        }



        ///
        [HttpDelete("{studentId}/{groupId}")]
        public async Task<IActionResult> DeleteStudentGroup(int studentId, int groupId)
        {
            var studentGroup = await _context.Student_Groups.FindAsync(studentId, groupId);
            if (studentGroup == null)
            {
                return NotFound();
            }

            _context.Student_Groups.Remove(studentGroup);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
