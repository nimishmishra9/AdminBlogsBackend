using AdminBlogs.Models;
using AdminBlogs.Services;
using Microsoft.AspNetCore.Mvc;

namespace AdminBlogs.Controllers
{
    public class StudentController : Controller
    {

        private IAuthService _authService;
        public StudentController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet(Name = "GetStudentDetials")]
        public IEnumerable<Student> UserDetails()
        {
            return null;
           // _authService.UserDetails();
        }
    }
}
