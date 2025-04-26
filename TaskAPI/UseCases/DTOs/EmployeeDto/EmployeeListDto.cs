using TaskAPI.Core.Enums;

namespace TaskAPI.UseCases.DTOs.EmployeeDto
{
    public class EmployeeListDto
    {
        public Guid Id { get; set; }
        public DateTime JoinDate { get; set; }
        public required string Name { get; set; }
        public required string Phone { get; set; }
        public Gender Gender { get; set; }
        public decimal Salary { get; set; }
    }
}
