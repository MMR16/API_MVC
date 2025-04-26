using System.ComponentModel.DataAnnotations;

namespace TaskAPI.Core.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime JoinDate { get; set; } 
    }
}
