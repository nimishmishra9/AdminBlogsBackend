using AdminBlogs.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdminBlogs.Services
{
    public interface IAuthService
    {
        public IEnumerable<UserModel> UserDetails();
        public UserModel Authenticate(Login login);
        public string BuildToken(UserModel user);
    }
}
