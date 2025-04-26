using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TaskMVC.Models;
using TaskMVC.Models.Employee;
using TaskMVC.Services;

namespace TaskMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TaskApiService _taskApiService;
        public HomeController(ILogger<HomeController> logger, TaskApiService taskApiService)
        {
            _logger = logger;
            _taskApiService = taskApiService;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var model = await _taskApiService.GetEmployeesAsync(cancellationToken);
            return View(model);
        }

        public async Task<IActionResult> EmployeeDetails(Guid id, CancellationToken cancellationToken)
        {
            var model = await _taskApiService.GetEmployeeByIdAsync(id, cancellationToken);
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> AddEmployee()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddEmployee(EmployeeById employeeToAdd)
        {
            if (!ModelState.IsValid)
            {
                return View(employeeToAdd);
            }

            var employeeUpdate = new EmployeeAdd
            {
                Name = employeeToAdd.Name,
                Phone = employeeToAdd.Phone,
                Gender = employeeToAdd.Gender,
                Salary = employeeToAdd.Salary
            };

            var model = await _taskApiService.AddEmployeeAsync(employeeUpdate);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> UpdateEmployee(Guid id,CancellationToken cancellationToken)
        {
            var model = await _taskApiService.GetEmployeeByIdAsync(id, cancellationToken);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> UpdateEmployee(EmployeeById employeeToUpdate)
        {


            if (!ModelState.IsValid)
            {
                return View(employeeToUpdate);
            }

            var employeeUpdate = new EmployeeUpdate
            {
                Id = employeeToUpdate.Id,
                Name = employeeToUpdate.Name,
                Phone = employeeToUpdate.Phone,
                Gender = employeeToUpdate.Gender,
                Salary = employeeToUpdate.Salary
            };

            var model = await _taskApiService.UpdateEmployeeAsync(employeeUpdate);
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> DeleteEmployee(Guid id,CancellationToken cancellationToken)
        {
            var model = await _taskApiService.DeteleEmployeeAsync(id, cancellationToken);
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
