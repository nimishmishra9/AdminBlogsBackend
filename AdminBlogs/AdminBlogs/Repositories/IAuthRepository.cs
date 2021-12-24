using AdminBlogs.Models;

namespace AdminBlogs.Repositories
{
    public interface IAuthRepository
    {
        public IEnumerable<UserModel> UserDetails();
        public UserModel Authenticate(Login login);
    }
}
