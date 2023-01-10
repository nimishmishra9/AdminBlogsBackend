using System.ComponentModel.DataAnnotations;

namespace AdminBlogs.Models
{
    public class Student
    {
        [Required]
        public string StudentName { get; set; }
        [Key]
        [Required, EmailAddress]
        public string StudentEmail { get; set; }
        [Required]
        public string StudentMobile { get; set; }
        [Required]
       
        public string FullAddress { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        [Required]
        public string AdharNumber { get; set; }
        [Required]
        public string Class { get; set; }
        [Required]
        public string FatherName { get; set; }
        [Required]
        public string motherName { get; set; }
        
    }
}
