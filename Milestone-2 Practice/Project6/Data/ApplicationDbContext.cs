using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project6.Models;
using Microsoft.EntityFrameworkCore;

namespace Project6.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> ops):base(ops){}

        public DbSet<MusicRecord> MusicRecords{get; set;}
        public DbSet<Order> Orders{get; set;}
    }
}