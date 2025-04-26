using TaskMVC.Models.Employee.Enums;

namespace TaskMVC.Models.Employee
{
    public class EmployeeById
    {
        public Guid Id { get; set; }
        public DateTime JoinDate { get; set; }
        public required string Name { get; set; }
        public required string Phone { get; set; }
        public Gender Gender { get; set; }
        public decimal Salary { get; set; }
    }
}
