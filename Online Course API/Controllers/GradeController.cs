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
    public class GradeController : ControllerBase
    {
        private readonly OnlineCourseDBContext context;

        private readonly IMapper mapper;

        public GradeController(OnlineCourseDBContext _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(mapper.Map<IEnumerable<GradeDTO>>(context.Grades.ToList()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            
        }


        [HttpGet("{ID:int}")]
        public IActionResult GetOneByID(int ID)
        {
            Grade grade = context.Grades.Find(ID);
            if (grade == null)
            {
                return NotFound();
            }
            else
            {
                try
                {
                    return Ok(mapper.Map<GradeDTO>(grade));
                }
                catch (Exception ex)
                {
                    return BadRequest(ex);
                }
                
            }
        }


        [HttpPost]
        public IActionResult Add(GradeDTO gradeDto)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    context.Grades.Add(mapper.Map<Grade>(gradeDto));
                    context.SaveChanges();

                    string URL = Url.Action(nameof(GetOneByID), new { ID = gradeDto.Grade_ID });

                    return Created(URL, gradeDto);
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


        [HttpPut("{ID:int}")]
        public IActionResult Update(GradeDTO gradeDto, int ID)
        {

            if (ModelState.IsValid)
            {
                
                Grade oldGrade = context.Grades.Find(ID);
                if (oldGrade != null)
                {
                    try
                    {
                        gradeDto.Grade_ID = ID;
                        mapper.Map(gradeDto, oldGrade);
                        context.Grades.Update(oldGrade);
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


        [HttpDelete("{ID:int}")]
        public IActionResult Delete(int ID)
        {

            Grade grade = context.Grades.Find(ID);
            if (grade != null)
            {
                try
                {
                    context.Grades.Remove(grade);
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
