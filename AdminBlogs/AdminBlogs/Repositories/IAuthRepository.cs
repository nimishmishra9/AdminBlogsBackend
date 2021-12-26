using AdminBlogs.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdminBlogs.Repositories
{
    public interface IAuthRepository
    {
        public IEnumerable<UserModel> UserDetails();
        public UserModel Authenticate(Login login);
        public OkObjectResult UserRegistration(UserModel userModel);
    }
}
