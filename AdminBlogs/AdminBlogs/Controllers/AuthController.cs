using AdminBlogs.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace AdminBlogs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly AdminBlogsContext _AdminBlogsContext;
        private IConfiguration _config;
        public AuthController(AdminBlogsContext AdminBlogsContext, IConfiguration config)
        {
            this._AdminBlogsContext = AdminBlogsContext;
            _config = config;
        }

        [AllowAnonymous]
        [HttpPost]
        [HttpGet(Name = "PostLoginDetails")]
        public IActionResult LoginUser([FromBody] Login login)
        {
            IActionResult response = Unauthorized();
            var user = Authenticate(login);

            if (user != null)
            {
                var tokenString = BuildToken(user);
                response = Ok(new { token = tokenString });
            }

            return Ok(Json(response, user));

        }
        private string BuildToken(UserModel user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        private UserModel Authenticate(Login login)
        {

            var user = _AdminBlogsContext.logins.Where(s => s.EmailId == login.EmailId && s.Passsword == login.Passsword).FirstOrDefault<Login>();
            if (user != null)
            {
                return _AdminBlogsContext.userModels.Where(s => s.Email == user.EmailId).FirstOrDefault();
            }
            return null;

        }
    }
}
