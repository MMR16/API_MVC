using System.ComponentModel.DataAnnotations;
using TaskMVC.Models.Employee.Enums;

namespace TaskMVC.Models.Employee
{
    public class EmployeeAdd
    {
        [MaxLength(300)]
        public required string Name { get; set; }
        [Phone]
        [MaxLength(15)]
        public required string Phone { get; set; }
        public Gender Gender { get; set; }
        [Range(1, double.MaxValue)]
        public decimal Salary { get; set; }
    }
}
