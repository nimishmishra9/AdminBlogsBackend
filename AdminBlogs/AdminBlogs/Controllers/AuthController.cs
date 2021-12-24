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
        private readonly AdminBlogsContext _AdminBlogsContext;
        
        private IAuthService _authService;
        public AuthController(IAuthService authService)
        {
           _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost(Name = "PostLoginDetails")]
        public IActionResult LoginUser([FromBody] Login login)
        {
            IActionResult response = Unauthorized();
            var user = _authService.Authenticate(login);
            if (user != null)
            {
                var tokenString = _authService.BuildToken(user);
                response = Ok(new { token = tokenString });
            }
            return Ok(Json(response, user));
        }
        
        [AllowAnonymous]
        [HttpGet(Name = "GetUserDetials")]
        public IEnumerable<UserModel> UserDetails()
        {
          return _authService.UserDetails();
        }
    }
}
