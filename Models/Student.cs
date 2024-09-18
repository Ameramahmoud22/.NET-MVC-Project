using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace First_MVC_App.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 3)]
        public string Name { get; set; }

        [Range(18, 25)]
        public int Age { get; set; }

        [ForeignKey("Department")]
        public int DeptNo { get; set; }

        [Required]
        [Remote(action: "CheckEmail", controller: "Student")]
        [RegularExpression(@"[a-zA-Z0-9_]+@[a-zA-Z]+.[a-zA-Z]{2,4}")]
        public string Email { get; set; }
       
        [Required,StringLength(15,MinimumLength =8)]
        public string Password { get; set; }

        [NotMapped]
        [Compare("Password")]
        public string CPassword { get; set; }

        public virtual Department Department { get; set; }

        public bool StuStatus { get; set; }

    }
}

