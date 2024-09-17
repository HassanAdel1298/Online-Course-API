using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Online_Course_API.Data;
using Online_Course_API.DTO;

namespace Online_Course_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorGroupsController : ControllerBase
    {
        private readonly OnlineCourseDBContext context;

        private readonly IMapper mapper;

        public InstructorGroupsController(OnlineCourseDBContext _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }

        [HttpGet ("{Instructor_ID:int}")]
        public IActionResult GetAll(int Instructor_ID)
        {
            try
            {
                return Ok(context.Groups
                        .Where(g => g.Instructor_ID == Instructor_ID)
                        .Select(g => new InstructorGroupsDTO 
                            {
                                Course_ID = g.Course_ID,
                                Course_Name = g.Course.Name,
                                Grade_ID = g.Course.Grade_ID,
                                Grade_Name = g.Course.Grade.Grade_Name,
                                Price = g.Price,
                                Group_ID = g.Group_ID,
                                GroupName = g.GroupName,
                                Num_Students = g.Num_Students,
                                Creation_Date = g.Creation_Date, 
                                End_Date = g.End_Date
                            })
                    );
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
    }
}
