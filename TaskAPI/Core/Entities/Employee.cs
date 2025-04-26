using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using TaskAPI.Core.Enums;
namespace TaskAPI.Core.Entities
{
    public class Employee : BaseEntity
    {
        [MaxLength(300)]
        public required string Name { get; set; }
        [Phone]
        [MaxLength(15)]
        public required string Phone { get; set; }
        public Gender Gender { get; set; }
        [Precision(18, 2)]
        public decimal Salary { get; set; }
    }
}
