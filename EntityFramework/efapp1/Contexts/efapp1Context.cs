

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using efapp1.Classess;
using System.IO;


namespace efapp1.Contexts{

public class efapp1Context: DbContext
{
    public DbSet<Employee> Employees { get; set;}
    public DbSet<Department> Departments{  get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = configuration.GetConnectionString("Local");

        optionsBuilder.UseSqlServer(connectionString);
    }
}
}