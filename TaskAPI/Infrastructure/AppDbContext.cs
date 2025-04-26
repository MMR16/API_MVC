using Microsoft.EntityFrameworkCore;
using TaskAPI.Core.Entities;

namespace TaskAPI.Infrastructure
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){ }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>()
                .HasKey(e => e.Id);
            modelBuilder.Entity<Employee>()
               .Property(e => e.Gender)
               .HasConversion<string>();
        }

        public override int SaveChanges()
        {
            SetAuditFields();
            return base.SaveChanges();
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            SetAuditFields();
            return await base.SaveChangesAsync(cancellationToken);
        }

       
        public DbSet<Employee> Employees { get; set; }



        private void SetAuditFields()
        {
            var entries = ChangeTracker.Entries<BaseEntity>().Where(e => e.State == EntityState.Added);

            foreach (var entry in entries)
            {
                entry.Entity.JoinDate = DateTime.UtcNow.AddHours(3);
            }
        }
    }

}
