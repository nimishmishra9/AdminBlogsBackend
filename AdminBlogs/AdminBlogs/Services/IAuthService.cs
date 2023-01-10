using AdminBlogs.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdminBlogs.Services
{
    public interface IAuthService
    {
        public IEnumerable<User> UserDetails();
        public User Authenticate(Login login);
        public string BuildToken(User user);
        public OkObjectResult UserRegistration(User userModel);
    }
}
