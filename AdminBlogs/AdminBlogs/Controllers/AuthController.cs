using AdminBlogs.Models;
using AdminBlogs.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdminBlogs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private IAuthService _authService;
        public AuthController(IAuthService authService)
        {
           _authService = authService;
        }

        
        [HttpPost]
        [Route("PostLoginDetails")]
        public IActionResult LoginUser([FromBody] Login login)
        {
            IActionResult response = Unauthorized();
            var user = _authService.Authenticate(login);
            if (user != null)
            {
                var tokenString = _authService.BuildToken(user);
                response = Ok(new { token = tokenString });
                return Ok(Json(response, user));
            }
            return StatusCode(404, "User does not exist");
        }
        
      
        [HttpPost]
        [Route("UsersRegistration")]
        public OkObjectResult UserRegistration(User userModel)
        {
            return   _authService.UserRegistration(userModel);
        }

        
        [HttpGet(Name = "GetUserDetials")]
        public IEnumerable<User> UserDetails()
        {
          return _authService.UserDetails();
        }
    }
}
