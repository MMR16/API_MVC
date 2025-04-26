using System.Net.Http;
using System.Threading;
using TaskMVC.Models.Employee;

namespace TaskMVC.Services
{
    public sealed class TaskApiService
    {
        private readonly HttpClient _httpClient;

        public TaskApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<EmployeeList>?> GetEmployeesAsync(CancellationToken cancellationToken)
        {
            var response = await _httpClient.GetFromJsonAsync<List<EmployeeList>>("employees", cancellationToken);
            return response;
        }

        public async Task<EmployeeById?> GetEmployeeByIdAsync(Guid id,CancellationToken cancellationToken)
        {
            var response = await _httpClient.GetFromJsonAsync<EmployeeById>($"employees/{id}", cancellationToken);
            return response;
        }

        public async Task<string?> UpdateEmployeeAsync(EmployeeUpdate employee)
        {
            var response = await _httpClient.PutAsJsonAsync($"employees/{employee.Id}",employee);
            var message = await response.Content.ReadAsStringAsync();
            return message;
        }

        public async Task<string?> AddEmployeeAsync(EmployeeAdd employee)
        {
            var response = await _httpClient.PostAsJsonAsync($"employees", employee);
            var message = await response.Content.ReadAsStringAsync();
            return message;
        }

        public async Task<string?> DeteleEmployeeAsync(Guid id,CancellationToken cancellationToken)
        {
            var response = await _httpClient.DeleteAsync($"employees/{id}", cancellationToken);
            var message = await response.Content.ReadAsStringAsync();
            return message;
        }
    }
}
