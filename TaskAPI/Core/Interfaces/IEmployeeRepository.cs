using Ardalis.Result;
using TaskAPI.Core.Entities;

namespace TaskAPI.Core.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<Result<Employee>> GetEmployeeByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<Result<List<Employee>>> GetAllEmployeesAsync(CancellationToken cancellationToken);
        Task<Result<Guid>> AddEmployeeAsync(Employee employee);
        Task<Result<Guid>> UpdateEmployeeAsync(Employee employee);
        Task<Result<string>> DeleteEmployeeAsync(Employee employee);
    }
}
