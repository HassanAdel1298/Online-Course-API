using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Online_Course_API.Data;
using Online_Course_API.DTO;
using Online_Course_API.Model;

namespace Online_Course_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class GroupController : ControllerBase
    {
        private readonly OnlineCourseDBContext context;

        private readonly IMapper mapper;

        public GroupController(OnlineCourseDBContext _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }
        //[Authorize(Roles = "Student")]
        //[Authorize(Roles = "Instructor")]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(mapper.Map<IEnumerable<GroupDTO>>(context.Groups.ToList()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        //[Authorize(Roles = "Student")]
        //[Authorize(Roles = "Instructor")]
        [HttpGet("{ID:int}")]
        public IActionResult GetOneByID(int ID)
        {
            Group group = context.Groups.Find(ID);
            if (group == null)
            {
                return NotFound();
            }
            else
            {
                try
                {
                    return Ok(mapper.Map<GroupDTO>(group));
                }
                catch (Exception ex)
                {
                    return BadRequest(ex);
                }

            }
        }

        //[Authorize(Roles = "Instructor")]
        [HttpPost]
        public IActionResult Add(GroupDTO groupDto)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    Instructor_Course instructorCourse = context.Instructor_Courses
                        .FirstOrDefault(IC => IC.Instructor_ID == groupDto.Instructor_ID
                                     && IC.Course_ID == groupDto.Course_ID);
                    if (instructorCourse == null)
                    {
                        context.Instructor_Courses.Add(new Instructor_Course()
                        {
                            Instructor_ID = groupDto.Instructor_ID,
                            Course_ID = groupDto.Course_ID
                        });
                    }

                    int durationMonth = context.Courses.Find(groupDto.Course_ID).Duration;
                    groupDto.End_Date = groupDto.Creation_Date.AddMonths(durationMonth);
                    context.Groups.Add(mapper.Map<Group>(groupDto));
                    context.SaveChanges();

                    string URL = Url.Action(nameof(GetOneByID), new { ID = groupDto.Group_ID });

                    return Created(URL, groupDto);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex);
                }

            }
            else
            {
                return BadRequest(ModelState);
            }
        }


        //[Authorize(Roles = "Instructor")]
        [HttpPut("{ID:int}")]
        public IActionResult Update(GroupDTO groupDto, int ID)
        {

            if (ModelState.IsValid)
            {

                Group oldGroup = context.Groups.Find(ID);
                if (oldGroup != null)
                {
                    try
                    {
                        groupDto.Group_ID = ID;
                        mapper.Map(groupDto, oldGroup);
                        context.Groups.Update(oldGroup);
                        context.SaveChanges();

                        return Ok();
                    }
                    catch (Exception ex)
                    {
                        return BadRequest(ex);
                    }

                }
                else
                {
                    return NotFound();
                }

            }
            else
            {
                return BadRequest(ModelState);
            }
        }


        //[Authorize(Roles = "Instructor")]
        [HttpDelete("{ID:int}")]
        public IActionResult Delete(int ID)
        {

            Group group = context.Groups.Find(ID);
            if (group != null)
            {
                try
                {
                    context.Groups.Remove(group);
                    context.SaveChanges();

                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex);
                }

            }
            else
            {
                return NotFound();
            }


        }

    }
}
