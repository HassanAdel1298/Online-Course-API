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
    public class InstructorController : ControllerBase
    {
        private readonly OnlineCourseDBContext _context;
        private readonly IMapper _mapper;
        public InstructorController(OnlineCourseDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [Authorize(Roles = "Student")]
        [HttpGet]
        public ActionResult<IEnumerable<InstructorDTO>> GetInstructors()
        {
            try
            {
                var instructors = _context.Instructors.ToList();
                var instructorDTOs = _mapper.Map<List<InstructorDTO>>(instructors);
                return Ok(instructorDTOs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        //[Authorize(Roles = "Instructor")]
        //[Authorize(Roles = "Student")]
        //[Authorize(Roles = "Parent")]
        [HttpGet("{id}")]
        public ActionResult<InstructorDTO> GetInstructor(int id)
        {
            var instructor = _context.Instructors.Find(id);

            if (instructor == null)
            {
                return NotFound();
            }

            try
            {
                var instructorDTO = _mapper.Map<InstructorDTO>(instructor);
                return Ok(instructorDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        //[Authorize(Roles = "Instructor")]
        [HttpPost]
        public IActionResult PostInstructor(InstructorDTO instructorDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var instructor = _mapper.Map<Instructor>(instructorDTO);

                _context.Instructors.Add(instructor);
                _context.SaveChanges();

                var createdInstructorDTO = _mapper.Map<InstructorDTO>(instructor);
                return CreatedAtAction(nameof(GetInstructor), new { id = instructor.Instructor_ID }, createdInstructorDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        //[Authorize(Roles = "Instructor")]
        [HttpPut("{id}")]
        public IActionResult PutInstructor(int id, InstructorDTO instructorDTO)
        {


            var instructor = _context.Instructors.Find(id);

            if (instructor == null)
            {
                return NotFound();
            }

            try
            {
                _mapper.Map(instructorDTO, instructor);
                _context.SaveChanges();

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteInstructor(int id)
        {
            var instructor = _context.Instructors.Find(id);

            if (instructor == null)
            {
                return NotFound();
            }

            try
            {
                _context.Instructors.Remove(instructor);
                _context.SaveChanges();

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }


        }

        //[HttpGet]
        //public ActionResult<IEnumerable<InstructorDTO>> GetInstructors()
        //{
        //    var instructors = _context.Instructors
        //        .Select(i => new InstructorDTO
        //        {
        //            Instructor_ID = i.Instructor_ID,
        //            First_Name = i.First_Name,
        //            Last_Name = i.Last_Name,
        //            Phone = i.Phone,
        //            Email = i.Email,
        //            Password = i.Password,
        //            Gender = i.Gender
        //        })
        //        .ToList();

        //    return Ok(instructors);
        //}


        //[HttpGet("{id}")]
        //public ActionResult<InstructorDTO> GetInstructor(int id)
        //{
        //    var instructor = _context.Instructors
        //        .Where(i => i.Instructor_ID == id)
        //        .Select(i => new InstructorDTO
        //        {
        //            Instructor_ID = i.Instructor_ID,
        //            First_Name = i.First_Name,
        //            Last_Name = i.Last_Name,
        //            Phone = i.Phone,
        //            Email = i.Email,
        //            Password = i.Password,
        //            Gender = i.Gender
        //        })
        //        .SingleOrDefault();

        //    if (instructor == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(instructor);
        //}


        //[HttpPost]
        //public IActionResult PostInstructor(InstructorDTO instructorDTO)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var instructor = new Instructor
        //    {
        //        First_Name = instructorDTO.First_Name,
        //        Last_Name = instructorDTO.Last_Name,
        //        Phone = instructorDTO.Phone,
        //        Email = instructorDTO.Email,
        //        Password = instructorDTO.Password,
        //        Gender = instructorDTO.Gender
        //    };

        //    _context.Instructors.Add(instructor);
        //    _context.SaveChanges();

        //    return CreatedAtAction(nameof(GetInstructor), new { id = instructor.Instructor_ID }, instructorDTO);
        //}


        //[HttpPut("{id}")]
        //public IActionResult PutInstructor(int id, InstructorDTO instructorDTO)
        //{
        //    if (id != instructorDTO.Instructor_ID)
        //    {
        //        return BadRequest();
        //    }

        //    var instructor = _context.Instructors.Find(id);

        //    if (instructor == null)
        //    {
        //        return NotFound();
        //    }

        //    // Update properties
        //    instructor.First_Name = instructorDTO.First_Name;
        //    instructor.Last_Name = instructorDTO.Last_Name;
        //    instructor.Phone = instructorDTO.Phone;
        //    instructor.Email = instructorDTO.Email;
        //    instructor.Password = instructorDTO.Password;
        //    instructor.Gender = instructorDTO.Gender;

        //    _context.SaveChanges();

        //    return NoContent();
        //}


        //[HttpDelete("{id}")]
        //public IActionResult DeleteInstructor(int id)
        //{
        //    var instructor = _context.Instructors.Find(id);

        //    if (instructor == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Instructors.Remove(instructor);
        //    _context.SaveChanges();

        //    return NoContent();
        //}

    }
}
