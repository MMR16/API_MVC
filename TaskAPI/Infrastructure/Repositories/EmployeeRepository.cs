using Ardalis.Result;
using Microsoft.EntityFrameworkCore;
using TaskAPI.Core.Entities;
using TaskAPI.Core.Interfaces;

namespace TaskAPI.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _dbContext;

        public EmployeeRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Result<Guid>> AddEmployeeAsync(Employee employee)
        {
            await _dbContext.AddAsync(employee);
            await _dbContext.SaveChangesAsync();
            return Result<Guid>.Success(employee.Id,"Added Successfully");
        }

        public async Task<Result<string>> DeleteEmployeeAsync(Employee employee)
        {
            _dbContext.Remove(employee);
            await _dbContext.SaveChangesAsync();
           return Result.Success("Deleted Successfully");
        }

        public async Task<Result<List<Employee>>> GetAllEmployeesAsync(CancellationToken cancellationToken)
        {
          var employees=await _dbContext.Employees.ToListAsync(cancellationToken);
            return Result<List<Employee>>.Success(employees);
        }

        public async Task<Result<Employee>> GetEmployeeByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var employee =await _dbContext.FindAsync<Employee>(id);
            if (employee is null)
                return Result<Employee>.NotFound("Employee not Found");

            return Result<Employee>.Success(employee);
        }

        public async Task<Result<Guid>> UpdateEmployeeAsync(Employee employee)
        {
            _dbContext.Update(employee);
            await _dbContext.SaveChangesAsync();
            return Result<Guid>.Success(employee.Id,"Updated Successfully");
        }
    }
}
