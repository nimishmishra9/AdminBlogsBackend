using AdminBlogs.Models;
using AdminBlogs.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NPOI.SS.Formula.Functions;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace AdminBlogs.Services
{
    public class AuthService : IAuthService
    {
        public IAuthRepository _authRepository;
        private IConfiguration _config;
        public AuthService(IAuthRepository authRepository, IConfiguration config)
        {
            this._authRepository = authRepository;
            this._config = config;
        }
        public IEnumerable<UserModel> UserDetails()
        {
            return _authRepository.UserDetails();
        }

        public UserModel Authenticate(Login login)
        {
            return _authRepository.Authenticate(login);
        }
        public string BuildToken(UserModel user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public  OkObjectResult UserRegistration(UserModel userModel)
        {
            return _authRepository.UserRegistration(userModel);
        }
    }
}
