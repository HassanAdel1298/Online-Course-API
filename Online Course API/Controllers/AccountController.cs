using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Online_Course_API.Data;
using Online_Course_API.DTO;
using Online_Course_API.Model;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Online_Course_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AccountController : ControllerBase
    {

        private readonly UserManager<ApplicationUser> usermanger;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration config;
        private readonly OnlineCourseDBContext _Context;
        private readonly IMapper _mapper;

        public AccountController(UserManager<ApplicationUser> usermanger,
            RoleManager<IdentityRole> roleManager,
            IConfiguration config,
            OnlineCourseDBContext _Context,
            IMapper _mapper)
        {
            this.usermanger = usermanger;
            this.config = config;
            this.roleManager = roleManager;
            this._Context = _Context;
            this._mapper = _mapper;
        }


        [HttpPost("GetID")]
        public async Task<IActionResult> GetID(GetidDto getidDto)
        {
            try
            {
                ApplicationUser user = await usermanger.FindByNameAsync(getidDto.username);

                if (user is null)
                {
                    return BadRequest("user name is not found !");
                }

                if (getidDto.role == "Student")
                {

                    Student student = _Context.Students.Where(s => s.UserId == user.Id).
                        FirstOrDefault();
                    return Ok(student.Student_ID);

                }
                else if (getidDto.role == "Instructor")
                {

                    Instructor instructor = _Context.Instructors.Where(i => i.UserId == user.Id).
                        FirstOrDefault();
                    return Ok(instructor.Instructor_ID);

                }
                else
                {
                    return BadRequest("role is not found !");
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }



        [HttpPost("register")]
        public async Task<IActionResult> Registration(RegisterUserDto userDto)
        {

            //if (ModelState.IsValid)
            //{


            //    ApplicationUser user = new ApplicationUser();
            //    user.UserName = userDto.UserName;
            //    user.Email = userDto.Email;
            //    IdentityResult result = await usermanger.CreateAsync(user, userDto.Password);
            //    if (result.Succeeded)
            //    {
            //        if (!string.IsNullOrEmpty(userDto.Role))
            //        {

            //            if (!await roleManager.RoleExistsAsync(userDto.Role))
            //            {
            //                await roleManager.CreateAsync(new IdentityRole(userDto.Role));
            //            }

            //            //await usermanger.AddToRoleAsync(user, userDto.Role);
            //            //var message = $"User account created successfully with role: {userDto.Role}";
            //            //return Ok(new { message });


            //            await usermanger.AddToRoleAsync(user, userDto.Role);


            //            if (userDto.Role == "Instructor")
            //            {

            //                _Context.Instructors.Add(new Instructor { UserId = user.Id });
            //            }
            //            else if (userDto.Role == "Student")
            //            {

            //                _Context.Students.Add(new Student { UserId = user.Id });
            //            }

            //            await _Context.SaveChangesAsync();

            //            return Ok();

            //        }
            //        else
            //        {

            //            return BadRequest("Role name is required.");
            //        }
            //    }
            //    else
            //    {
            //        return BadRequest(result.Errors.FirstOrDefault()?.Description);
            //    }

            //}
            //return BadRequest("Here");

            if (ModelState.IsValid)
            {

                try
                {
                    ApplicationUser existingUser = await usermanger.FindByEmailAsync(userDto.Email);

                    if (existingUser != null)
                    {
                        return BadRequest("Email address is already in use.");
                    }

                    ApplicationUser user = new ApplicationUser();
                    user.UserName = userDto.UserName;
                    user.Email = userDto.Email;
                    user.Name = userDto.Name;

                    IdentityResult result = await usermanger.CreateAsync(user, userDto.Password);

                    if (result.Succeeded)
                    {
                        if (!string.IsNullOrEmpty(userDto.Role))
                        {

                            _Context.SaveChanges();
                            // Add user details to corresponding tables based on role
                            switch (userDto.Role)
                            {

                                case "INSTRUCTOR":
                                case "instructor":
                                case "Instructor":

                                    if (!await roleManager.RoleExistsAsync(UserRoles.Instructor))
                                    {
                                        await roleManager.CreateAsync(new IdentityRole(UserRoles.Instructor));
                                    }

                                    await usermanger.AddToRoleAsync(user, UserRoles.Instructor);

                                    InstructorDTO instructorDTO = new InstructorDTO()
                                    {
                                        UserId = user.Id,
                                        ApplicationUser = user

                                    };

                                    Instructor instructor = _mapper.Map<Instructor>(instructorDTO);

                                    _Context.Instructors.Add(instructor);
                                    _Context.SaveChanges();

                                    // Add user details to Instructor table
                                    //_Context.Instructors.Add(new Instructor
                                    //{
                                    //    UserId = user.Id,
                                    //    ApplicationUser = user
                                    //    //First_Name = user.UserName,
                                    //    //Email = user.Email,
                                    //    //Password = userDto.Password // Store password in plain text (not recommended)
                                    //});

                                    break;

                                case "STUDENT":
                                case "student":
                                case "Student":

                                    if (!await roleManager.RoleExistsAsync(UserRoles.Student))
                                    {
                                        await roleManager.CreateAsync(new IdentityRole(UserRoles.Student));
                                    }

                                    await usermanger.AddToRoleAsync(user, UserRoles.Student);

                                    StudentDTO studentDTO = new StudentDTO()
                                    {
                                        UserId = user.Id,
                                        ApplicationUser = user

                                    };

                                    Student student = _mapper.Map<Student>(studentDTO);

                                    _Context.Students.Add(student);
                                    _Context.SaveChanges();

                                    // Add user details to Student table
                                    //_Context.Students.Add(new Student
                                    //{
                                    //    UserId = user.Id,
                                    //    ApplicationUser = user
                                    //    //First_Name = user.UserName,
                                    //    //Email = user.Email,
                                    //    //Password = userDto.Password // Store password in plain text (not recommended)
                                    //});
                                    break;


                                default:
                                    // Invalid role
                                    return BadRequest("Invalid role.");
                            }
                            //await _Context.SaveChangesAsync();

                            return Ok();
                        }
                        else
                        {
                            return BadRequest("Role name is required.");
                        }
                    }
                    else
                    {
                        string Error = string.Empty;
                        foreach (var error in result.Errors)
                            Error += $"{error.Description} , ";

                        return BadRequest(Error);
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

            }
            return BadRequest(ModelState);

        }


        //[HttpPost("login")]

        //public async Task<IActionResult> Login(LoginUserDto userDto)
        //{
        //    if (ModelState.IsValid == true)
        //    {

        //        ApplicationUser user = await usermanger.FindByNameAsync(userDto.UserName);
        //        if (user != null)
        //        {
        //            bool found = await usermanger.CheckPasswordAsync(user, userDto.Password);
        //            if (found)
        //            {

        //                var claims = new List<Claim>();

        //                claims.Add(new Claim(ClaimTypes.Role, "Instructor"));
        //                claims.Add(new Claim(ClaimTypes.Role, "Student"));



        //                claims.Add(new Claim(ClaimTypes.Name, user.UserName));
        //                claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
        //                claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));


        //                var roles = await usermanger.GetRolesAsync(user);
        //                foreach (var itemRole in roles)
        //                {
        //                    claims.Add(new Claim(ClaimTypes.Role, itemRole));
        //                    switch (itemRole)
        //                    {
        //                        case "Instructor":
        //                            claims.Add(new Claim("Instructor", "true"));
        //                            break;
        //                        case "Student":
        //                            claims.Add(new Claim("Student", "true"));
        //                            break;


        //                    }
        //                }

        //                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:SecretKey"]));
        //                var sc = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        //                JwtSecurityToken mytoken = new JwtSecurityToken(
        //                    issuer: config["JWT:ValidIssuer"],
        //                    audience: config["JWT:ValidAudiance"],
        //                    claims: claims,
        //                    expires: DateTime.Now.AddHours(1),
        //                       signingCredentials: sc
        //                    );
        //                return Ok(new
        //                {
        //                    token = new JwtSecurityTokenHandler().WriteToken(mytoken),
        //                    expiration = mytoken.ValidTo
        //                });
        //            }
        //        }
        //        return Unauthorized();

        //    }
        //    return Unauthorized("Invalid username or password.");
        //}




        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserDto userDto)
        {
            if (ModelState.IsValid == true)
            {

                ApplicationUser user = await usermanger.FindByNameAsync(userDto.UserName);


                if (user is null || !await usermanger.CheckPasswordAsync(user, userDto.Password))
                {
                    return Unauthorized("User Name or Password invalid !");
                }


                JwtSecurityToken jwtSecurityToken = await CreateJwtToken(user);

                var roles = await usermanger.GetRolesAsync(user);

                return Ok(new
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                    ExpireOn = jwtSecurityToken.ValidTo,
                    Roles = roles.FirstOrDefault(),
                    Email = user.Email,
                    UserName = user.UserName,

                });

            }
            return Unauthorized();

        }



        private async Task<JwtSecurityToken> CreateJwtToken(ApplicationUser user)
        {
            var userClaims = await usermanger.GetClaimsAsync(user);
            var roles = await usermanger.GetRolesAsync(user);
            var roleClaims = new List<Claim>();

            foreach (var role in roles)
            {
                roleClaims.Add(new Claim(ClaimTypes.Role, role));
                switch (role)
                {

                    case UserRoles.Instructor:
                        roleClaims.Add(new Claim(UserRoles.Instructor, "true"));
                        break;

                    case UserRoles.Student:
                        roleClaims.Add(new Claim(UserRoles.Student, "true"));
                        break;


                }
            }


            var claims = new[]
            {
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                }

            .Union(userClaims)
            .Union(roleClaims);

            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey
                (Encoding.UTF8.GetBytes(config["JWT:SecretKey"]));

            SigningCredentials signingCredentials = new SigningCredentials(symmetricSecurityKey,
                SecurityAlgorithms.HmacSha256);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer: config["JWT:ValidIssuer"],
                audience: config["JWT:ValidAudiance"],
                claims: claims,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }
    }
}
