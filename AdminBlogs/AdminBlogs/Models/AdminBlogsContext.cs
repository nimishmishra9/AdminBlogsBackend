using Microsoft.EntityFrameworkCore;

namespace AdminBlogs.Models
{
    public class AdminBlogsContext : DbContext
    {
      
        public AdminBlogsContext(DbContextOptions<AdminBlogsContext> options):base(options)
        {

        }
        public DbSet<Login> logins { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Student> students { get; set; }
    }
}
