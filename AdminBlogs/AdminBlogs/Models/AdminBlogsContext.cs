using Microsoft.EntityFrameworkCore;

namespace AdminBlogs.Models
{
    public class AdminBlogsContext : DbContext
    {
      
        public AdminBlogsContext(DbContextOptions<AdminBlogsContext> options):base(options)
        {

        }
        public DbSet<Login> logins { get; set; }
        public DbSet<UserModel> userModels { get; set; }
    }
}
