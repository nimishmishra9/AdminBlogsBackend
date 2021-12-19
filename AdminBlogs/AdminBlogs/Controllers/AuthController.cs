using AdminBlogs.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdminBlogs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly AdminBlogsContext _AdminBlogsContext;
        public AuthController(AdminBlogsContext AdminBlogsContext)
        {
            this._AdminBlogsContext = AdminBlogsContext;
        }
        [HttpGet(Name = "GetLoginDetails")]
        public IEnumerable<Login> Get()
        {
            return _AdminBlogsContext.logins.ToList<Login>();
        }
    }
}
