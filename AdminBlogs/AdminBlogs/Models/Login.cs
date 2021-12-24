using System.ComponentModel.DataAnnotations;

namespace AdminBlogs.Models
{
    public class Login
    {
        [Key]
        [EmailAddress]
        [Required(ErrorMessage ="Email Is required")]
        public string EmailId {get;set;}
        [Required]
        public string Passsword {get;set;}
    }
}
