using TaskAPI.Core.Entities;
using TaskAPI.UseCases.DTOs.EmployeeDto;

namespace TaskAPI.UseCases.Mapper
{
    public static class EmployessMapper
    {
        public static Employee ToEmployee(AddEmployeeDto employee)
        {
            var mappedEmployee = new Employee
            {
                Name = employee.Name,
                Phone = employee.Phone,
                Gender = employee.Gender,
                Salary = employee.Salary
            };

            return mappedEmployee;
        }

        public static Employee SetEmployeeUpdatedData(this Employee employee, UpdateEmployeeDto Updatedemployee)
        {

            employee.Name = Updatedemployee.Name;
            employee.Phone = Updatedemployee.Phone;
            employee.Gender = Updatedemployee.Gender;
            employee.Salary = Updatedemployee.Salary;
            return employee;
        }

        public static List<EmployeeListDto> GetEmployees(List<Employee> employees)
        {
            var mappedEmps = employees.Select(e => new EmployeeListDto
            {
                Id = e.Id,
                Name = e.Name,
                Phone = e.Phone,
                Gender = e.Gender,
                Salary = e.Salary,
                JoinDate = e.JoinDate
            }).ToList();
            return mappedEmps;
        }


        public static GetEmpoyeeByIdDto GetEmployee(Employee employee)
        {

            var mappedEmployee = new GetEmpoyeeByIdDto
            {
                Id = employee.Id,
                Name = employee.Name,
                Phone = employee.Phone,
                Gender = employee.Gender,
                Salary = employee.Salary,
                JoinDate = employee.JoinDate
            };

            return mappedEmployee;
        }
    }
}
