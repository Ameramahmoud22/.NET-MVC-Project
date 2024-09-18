using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace First_MVC_App.Models
{
    public class Course
    {
        public int CourseId { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 3)]
        public string CourseName { get; set; }

        [Range(30, 60)]
        public int Duration { get; set; }

        [ForeignKey("Department")]
        public int DeptNo { get; set; }
        public virtual Department Department { get; set; }
    }
}
