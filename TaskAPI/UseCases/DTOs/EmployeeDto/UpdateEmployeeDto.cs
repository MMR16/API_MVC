using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TaskAPI.Core.Enums;

namespace TaskAPI.UseCases.DTOs.EmployeeDto
{
    public class UpdateEmployeeDto
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        [MaxLength(300)]
        public required string Name { get; set; }
        [Phone]
        [MaxLength(15)]
        public required string Phone { get; set; }
        public Gender Gender { get; set; }
        [Precision(18, 2)]
        [Range(1, double.MaxValue)]
        public decimal Salary { get; set; }
    }
}
