using AdminBlogs.Models;
using AdminBlogs.Repositories;
using AdminBlogs.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AdminBlogsContext>(options => {
    options.UseSqlServer("Data Source=DESKTOP-CAGAKSJ\\NIMISHDB;Initial Catalog=AdminBlogs;User ID=sa;Password=Sbsstc@123");
});
builder.Services.AddControllers();
builder.Services.AddTransient<IAuthService, AuthService>();
builder.Services.AddTransient<IAuthRepository, AuthRepository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(option => {
    var serverSecret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("veryVerySecretKey"));
    option.TokenValidationParameters = new TokenValidationParameters
    {
        IssuerSigningKey = serverSecret,
        ValidIssuer = "https://localhost:7031/",
        ValidAudience = "*",
    };
});

 

var app = builder.Build();
app.UseAuthentication();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
