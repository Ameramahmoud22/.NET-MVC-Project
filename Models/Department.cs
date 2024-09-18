using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace First_MVC_App.Models
{
    public class Department
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DeptId { get; set; }

        [StringLength(15)]
        public string DeptName { get; set; }
        public int Capacity { get; set; }

        public virtual List<Student> Students { get; set; }
        public override string ToString()
        {
            return $"{DeptId}:{DeptName}:{Capacity}";
        }
        public bool DeptStatus { get; set; }

    }
}
