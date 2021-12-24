using System.ComponentModel.DataAnnotations;

namespace AdminBlogs.Models
{
    public class UserModel
    {
        [Required]
        public string Name { get; set; }
        [Key]
        [Required,EmailAddress]
        public string Email { get; set; }
        [Required]
        public string mobile { get; set; }
        [Required]
        public string role { get; set; }
        public DateTime Birthdate { get; set; }
    }
}
