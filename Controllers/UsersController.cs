using LoginWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoginWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserDbContext userDbContext;
        public UsersController(UserDbContext userDbContext) 

        {
            this.userDbContext = userDbContext;
        
        
        }

        [HttpPost]
        [Route("Registration")]

        public IActionResult Registration(UserDTO userDTO)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);  
            }

            var user = userDbContext.Users.FirstOrDefault(x => x.Email == userDTO.Email);

            if (user == null)
            {

                userDbContext.Users.Add(new User
                {
                    FirstName = userDTO.FirstName,
                    LastName = userDTO.LastName,
                    Email = userDTO.Email,
                    Password = userDTO.Password
                });


                userDbContext.SaveChanges();
                return Ok("User Registered Successfully");
            }
            return BadRequest("User Already exists");
        }

        [HttpPost]
        [Route("Login")]

        public IActionResult Login(LoginDTO loginDTO)
        {
            var loginuser = userDbContext.Users.FirstOrDefault(x => x.Email == loginDTO.Email && x.Password == loginDTO.Password);

            if (loginuser != null) {

                return Ok(loginuser);

            }
            return NoContent();
        }

        [HttpGet]
        [Route("GetUsers")]

        public IActionResult GetUsers()
        {
            return Ok(userDbContext.Users.ToList());
        }

        [HttpGet]
        [Route("GetUser")]

        public IActionResult GetUser(int id)
        {
            var user = userDbContext.Users.FirstOrDefault(x => x.UserId == id);
            if(user != null) {
                return Ok(user);
            }
            else
            {
                return NoContent();
            }

           
        }

    }
}
