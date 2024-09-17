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
    public class QuizController : ControllerBase
    {

        private readonly OnlineCourseDBContext context;

        private readonly IMapper mapper;

        public QuizController(OnlineCourseDBContext _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }

        //[Authorize(Roles = "Instructor")]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(mapper.Map<IEnumerable<QuizDTO>>(context.Quizzes.ToList()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        //[Authorize(Roles = "Parent")]
        [HttpGet("{ID:int}")]
        public IActionResult GetOneByID(int ID)
        {
            Quiz quiz = context.Quizzes.Find(ID);
            if (quiz == null)
            {
                return NotFound();
            }
            else
            {
                try
                {
                    return Ok(mapper.Map<QuizDTO>(quiz));
                }
                catch (Exception ex)
                {
                    return BadRequest(ex);
                }

            }
        }

        //[Authorize(Roles = "Instructor")]
        [HttpPost]
        public IActionResult Add(QuizDTO quizDto)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    context.Quizzes.Add(mapper.Map<Quiz>(quizDto));
                    context.SaveChanges();

                    //string URL = Url.Action(nameof(GetOneByID), new { ID = quizDto.Quiz_ID });

                    int id = context.Quizzes.OrderByDescending(q => q.Quiz_ID)
                        .FirstOrDefault().Quiz_ID;

                    return Ok(id);

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
        public IActionResult Update(QuizDTO quizDto, int ID)
        {

            if (ModelState.IsValid)
            {

                Quiz oldQuiz = context.Quizzes.Find(ID);
                if (oldQuiz != null)
                {
                    try
                    {
                        quizDto.Quiz_ID = ID;
                        mapper.Map(quizDto, oldQuiz);
                        context.Quizzes.Update(oldQuiz);
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

            Quiz quiz = context.Quizzes.Find(ID);
            if (quiz != null)
            {
                try
                {
                    context.Quizzes.Remove(quiz);
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
