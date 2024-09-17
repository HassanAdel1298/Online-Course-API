using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Online_Course_API.Data;
using Online_Course_API.DTO;

namespace Online_Course_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllSessionByGroupController : ControllerBase
    {
        private readonly OnlineCourseDBContext _context;
        private readonly IMapper _mapper;

        public AllSessionByGroupController(OnlineCourseDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("ByGroup/{groupId}")]
        public ActionResult<IEnumerable<ALlSessionDTO>> GetsessionsbyGroup(int groupId)
        {
            try
            {
                var sessions = _context.Sessions
                .Where(g => g.Group_ID == groupId).ToList();

                var allsessionByGroupDTO = _mapper.Map<List<ALlSessionDTO>>(sessions);
                return Ok(allsessionByGroupDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            
        }
    }
}
