using System.ComponentModel.DataAnnotations;

namespace AdminBlogs.Models
{
    public class User
    {
        [Required]
        public string Name { get; set; }
        [Key]
        [Required,EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Mobile { get; set; }
        [Required]
        public string Role { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Gender { get; set; }
        public DateTime ?BirthDate { get; set; }
        [Required]
        public string AdharNumber { get; set; }
    }
}
