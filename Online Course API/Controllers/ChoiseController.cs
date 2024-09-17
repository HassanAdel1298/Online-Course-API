using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Online_Course_API.Data;
using Online_Course_API.DTO;
using Online_Course_API.Mapper;
using Online_Course_API.Model;

namespace Online_Course_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChoiseController : ControllerBase
    {
        private readonly OnlineCourseDBContext context;

        private readonly IMapper mapper;

        public ChoiseController(OnlineCourseDBContext _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(mapper.Map<IEnumerable<ChoiseDTO>>(context.Choises.ToList()));
            }
            catch(Exception ex) 
            {
                return BadRequest(ex);
            }
            
        }


        [HttpGet("{ID:int}")]
        public IActionResult GetOneByID(int ID)
        {
            Choise choise = context.Choises.Find(ID);
            if (choise == null)
            {
                return NotFound();
            }
            else
            {
                try
                {
                    return Ok(mapper.Map<ChoiseDTO>(choise));
                }
                catch (Exception ex)
                {
                    return BadRequest(ex);
                }
            }
        }


        [HttpPost]
        public IActionResult Add(ChoiseDTO choiseDto)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    context.Choises.Add(mapper.Map<Choise>(choiseDto));
                    context.SaveChanges();

                    string URL = Url.Action(nameof(GetOneByID), new { ID = choiseDto.Choise_ID });

                    return Created(URL, choiseDto);
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
        public IActionResult Update(ChoiseDTO choiseDto, int ID)
        {

            if (ModelState.IsValid)
            {

                Choise oldChoise = context.Choises.Find(ID);
                if (oldChoise != null)
                {
                    try
                    {
                        choiseDto.Choise_ID = ID;
                        mapper.Map(choiseDto, oldChoise);
                        context.Choises.Update(oldChoise);
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

            Choise choise = context.Choises.Find(ID);
            if (choise != null)
            {
                try
                {
                    context.Choises.Remove(choise);
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
