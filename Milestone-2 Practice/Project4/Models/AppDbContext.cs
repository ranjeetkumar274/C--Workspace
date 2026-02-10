using Microsoft.EntityFrameworkCore;


namespace Project4.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> ops):base(ops){}

        public DbSet<Student> Students{get; set;}

        
    }
}