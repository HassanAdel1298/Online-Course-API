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
    public class SessionController : ControllerBase
    {
        private readonly OnlineCourseDBContext _context;
        private readonly IMapper _mapper;

        public SessionController(OnlineCourseDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //[Authorize(Roles = "Student")]
        [HttpGet]
        public ActionResult<IEnumerable<SessionDTO>> GetSessions()
        {
            try
            {
                var sessions = _context.Sessions.ToList();
                var sessionDTOs = _mapper.Map<List<SessionDTO>>(sessions);
                return Ok(sessionDTOs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }


        [HttpGet("{id}")]
        public ActionResult<SessionDTO> GetSession(int id)
        {
            var session = _context.Sessions.FirstOrDefault(s => s.Session_ID == id);
            if (session == null)
            {
                return NotFound();
            }

            try
            {
                var sessionDTO = _mapper.Map<SessionDTO>(session);
                return Ok(sessionDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        [HttpGet("Group/{Group_ID:int}")]
        public ActionResult<IEnumerable<SessionDTO>> GetSessionforGroup(int Group_ID)
        {
            try
            {
                var sessions = _context.Sessions.Where(s => s.Group_ID == Group_ID).ToList();
                var sessionDTOs = _mapper.Map<List<SessionDTO>>(sessions);
                return Ok(sessionDTOs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }


        [HttpPost]
        public IActionResult PostSession(SessionDTO sessionDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Group group = _context.Groups.Find(sessionDTO.Group_ID);
                if (sessionDTO.Start_Date < group.End_Date.ToDateTime(new TimeOnly(0, 0, 0, 0))
                    && group.Instructor_ID == sessionDTO.Instructor_ID)
                {
                    var session = _mapper.Map<Session>(sessionDTO);

                    _context.Sessions.Add(session);
                    _context.SaveChanges();

                    return CreatedAtAction(nameof(GetSession), new { id = session.Session_ID }, sessionDTO);
                }
                else
                {
                    return BadRequest("Not Can Add Session because date of session after end date for group or Instructor not create this group");
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }


        [HttpPut("{id}")]
        public IActionResult PutSession(int id, SessionDTO sessionDTO)
        {


            if (ModelState.IsValid)
            {

                Session oldSession = _context.Sessions.Find(id);
                if (oldSession != null)
                {
                    try
                    {
                        sessionDTO.Session_ID = id;
                        _mapper.Map(sessionDTO, oldSession);
                        _context.Sessions.Update(oldSession);
                        _context.SaveChanges();

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


        [HttpDelete("{id}")]
        public IActionResult DeleteSession(int id)
        {
            var session = _context.Sessions.Find(id);

            if (session == null)
            {
                return NotFound();
            }

            try
            {
                _context.Sessions.Remove(session);
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
