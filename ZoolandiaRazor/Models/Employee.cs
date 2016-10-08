using System.ComponentModel.DataAnnotations;

namespace ZoolandiaRazor.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int EmployeeAge { get; set; }
        public virtual Habitat HabitatId { get; set; }
    }
}