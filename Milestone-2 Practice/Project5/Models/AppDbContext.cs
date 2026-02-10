using System.Reflection;
using Microsoft.EntityFrameworkCore;


namespace Project5.Models
{
    public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> ops) : base(ops)
        {  
        }

        public DbSet<Book> Books{get; set;}

        protected override void OnModelCreating(ModelBuilder mb)
        {
            base.OnModelCreating(mb);
            mb.Entity<Book>().HasData(
                new Book{BookID = 1,Title = "1984",Author = "George Orwell",Genre = "Dystopian", AvailableCopies=3},
                new Book{BookID = 2,Title = "1985",Author = "George Orwelll",Genre = "Dystopian", AvailableCopies=6},
                new Book{BookID = 3,Title = "1986",Author = "Georgee Orwell",Genre = "Dystopiann", AvailableCopies=10}
            );
        }
}
}