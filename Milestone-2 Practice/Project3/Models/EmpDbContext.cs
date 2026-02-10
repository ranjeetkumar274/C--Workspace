using Microsoft.EntityFrameworkCore;


namespace Project3.Models
{
    public class EmpDbContext: DbContext
    {
        public EmpDbContext(DbContextOptions<EmpDbContext> ops):base(ops){}

        public DbSet<Employee> Employees{get; set;}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Employee>(e =>
            {
                e.HasKey(et => et.EmployeeId);
                e.ToTable("Employees");
                e.Property(et => et.Name).IsRequired().HasMaxLength(150);
                e.Property(et => et.Salary).IsRequired();
            });
        }
    }
}