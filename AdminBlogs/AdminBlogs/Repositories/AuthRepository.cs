using AdminBlogs.Models;

namespace AdminBlogs.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private AdminBlogsContext _adminBlogsContext;
        public AuthRepository(AdminBlogsContext adminBlogsContext)
        {
            _adminBlogsContext= adminBlogsContext;
        }
        public IEnumerable<UserModel> UserDetails()
        {
            return _adminBlogsContext.userModels.ToList();
        }

        public UserModel Authenticate(Login login)
        {
            var user = _adminBlogsContext.logins.Where(s => s.EmailId == login.EmailId && s.Passsword == login.Passsword).FirstOrDefault<Login>();
            if (user != null)
            {
                return _adminBlogsContext.userModels.Where(s => s.Email == user.EmailId).FirstOrDefault();
            }
            return null;
        }
    }
}
