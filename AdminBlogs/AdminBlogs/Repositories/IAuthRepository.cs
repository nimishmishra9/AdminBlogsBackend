using AdminBlogs.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdminBlogs.Repositories
{
    public interface IAuthRepository
    {
        public IEnumerable<User> UserDetails();
        public User Authenticate(Login login);
        public OkObjectResult UserRegistration(User userModel);
    }
}
