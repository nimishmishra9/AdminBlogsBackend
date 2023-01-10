using AdminBlogs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace AdminBlogs.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private AdminBlogsContext _adminBlogsContext;
        public AuthRepository(AdminBlogsContext adminBlogsContext)
        {
            _adminBlogsContext= adminBlogsContext;
        }
        public IEnumerable<User> UserDetails()
        {
            return _adminBlogsContext.users.ToList();
        }

        public User Authenticate(Login login)
        {
            var user = _adminBlogsContext.logins.Where(s => s.EmailId == login.EmailId && s.Passsword == login.Passsword).FirstOrDefault<Login>();
            if (user != null)
            {
                return _adminBlogsContext.users.Where(s => s.Email == user.EmailId).FirstOrDefault();
            }
            return null;
        }

        public OkObjectResult UserRegistration(User userModel)
        {
            try
            {
                var res = _adminBlogsContext.users.AddAsync(userModel);
                var response = _adminBlogsContext.SaveChanges();
                if(response==1)
                {
                    return new OkObjectResult(new { Message = "User added successfully!", status = "200" });
                }
                else
                {
                    return new OkObjectResult(new { Message = "User is not saved" });
                }
               
            }
            catch(Exception e)
            {
                SqlException innerException = e.InnerException as SqlException;
                if (innerException != null && (innerException.Number == 2627 || innerException.Number == 2601))
                {
                    return new OkObjectResult(new { Message = "User is already exist" });
                }
                else
                {
                    return new OkObjectResult(new { Message = "Internal server error" });

                }

            }
           
        }
    }
}

