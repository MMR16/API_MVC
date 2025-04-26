using Ardalis.Result;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using TaskAPI.Core.Interfaces;
using TaskAPI.UseCases.DTOs.EmployeeDto;
using TaskAPI.UseCases.Mapper;

namespace TaskAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;


        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees(CancellationToken cancellationToken)
        {
            var employeesResult = await _employeeRepository.GetAllEmployeesAsync(cancellationToken);
            if (employeesResult is null)
                return Ok();

            var mappedEmp = EmployessMapper.GetEmployees(employeesResult.Value);
            return Ok(mappedEmp);
        }

        [HttpGet("{id:guid}", Name = nameof(GetEmployeeById))]
        public async Task<IActionResult> GetEmployeeById(Guid id, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(id, cancellationToken);
            if (employee.Status == ResultStatus.NotFound || employee.IsSuccess is false)
                return NotFound();

            var mappdedEmp = EmployessMapper.GetEmployee(employee.Value);
            return Ok(mappdedEmp);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] AddEmployeeDto employee)
        {
            if (employee == null)
                return BadRequest("error in request");

            var mappedEmployee = EmployessMapper.ToEmployee(employee);
            await _employeeRepository.AddEmployeeAsync(mappedEmployee);
            return CreatedAtAction(nameof(GetEmployeeById), new { id = mappedEmployee.Id }, employee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(Guid id, [FromBody] UpdateEmployeeDto employee, CancellationToken cancellationToken)
        {
            if (employee == null)
                return BadRequest("error in request");

            var existinEmployee = await _employeeRepository.GetEmployeeByIdAsync(id, cancellationToken);
            if (existinEmployee.IsSuccess is false || existinEmployee.Status == ResultStatus.NotFound)
                return NotFound(existinEmployee);

            existinEmployee.Value.SetEmployeeUpdatedData(employee);
            var result = await _employeeRepository.UpdateEmployeeAsync(existinEmployee);

            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteEmployee(Guid id,CancellationToken cancellationToken)
        {
            var existinEmployee = await _employeeRepository.GetEmployeeByIdAsync(id,cancellationToken);
            if (existinEmployee.IsSuccess is false || existinEmployee.Status == ResultStatus.NotFound)
                return NotFound(existinEmployee);

            await _employeeRepository.DeleteEmployeeAsync(existinEmployee);
            return NoContent();
        }

    }
}
