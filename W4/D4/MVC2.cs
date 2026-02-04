// BookingController

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicianBookingSystem.Exceptions;
using MusicianBookingSystem.Models;

namespace MusicianBookingSystem.Controllers
{
    public class BookingController : Controller
    {
        private readonly ApplicationDbContext _context;

    public BookingController(ApplicationDbContext context)
        {
            _context = context;
        }

    public IActionResult Index()
        {
            var bookings = _context.Bookings
                                   .Include(b => b.Slot)
                                   .ToList();

    return View(bookings);
        }

    [HttpPost]
        public IActionResult Book(int id, int userId)
        {
            var slot = _context.Slots
                               .Include(s => s.Bookings)
                               .FirstOrDefault(s => s.SlotID == id);

    if (slot == null)
                return NotFound();

    if (slot.Bookings.Count >= slot.Capacity)
                throw new SlotBookingException("Slot is full.");

    if (slot.Bookings.Any(b => b.UserID == userId))
                throw new SlotBookingException("You have already booked this slot.");

    var booking = new Booking
            {
                SlotID = id,
                UserID = userId
            };

    _context.Bookings.Add(booking);
            _context.SaveChanges();

    return RedirectToAction("Index");
        }

    public IActionResult Summary(int userId)
        {
            var userBookings = _context.Bookings
                                       .Include(b => b.Slot)
                                       .Where(b => b.UserID == userId)
                                       .ToList();

    return View(userBookings);
        }
    }
}



// SlotController


using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicianBookingSystem.Models;

namespace MusicianBookingSystem.Controllers
{
    public class SlotController : Controller
    {
        private readonly ApplicationDbContext _context;

    public SlotController(ApplicationDbContext context)
        {
            _context = context;
        }

    public IActionResult Index()
        {
            var slots = _context.Slots
                                .Include(s => s.Bookings)
                                .ToList();

    return View(slots);
        }
    }
}



// SlotBookingException.cs


using System;

namespace MusicianBookingSystem.Exceptions{
    public class SlotBookingException:Exception{
        public SlotBookingException(string msg):base(msg){}
    }
}


// AppDbContext.cs


using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;

namespace MusicianBookingSystem.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> ops):base(ops){}

        public DbSet<Slot> Slots{get; set;}
        public DbSet<Booking> Bookings{get; set;}
    }
}



// Booking.cs
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicianBookingSystem.Models
{
    public class Booking
    {
    [Key]
    public int BookingID { get; set; }

    [ForeignKey("Slot")]
    public int SlotID { get; set; }

    public int UserID { get; set; }

    public Slot Slot { get; set; }
    }
}



// Slot.cs

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicianBookingSystem.Models
{
    public class Slot
    {
    [Key]
    public int SlotID { get; set; }

    public DateTime Time { get; set; }

    public int Duration { get; set; }

    public int Capacity { get; set; } = 5;

    public List<Booking> Bookings { get; set; } = new List <Booking>();
    }
}



// Program.cs

using Microsoft.EntityFrameworkCore;
using MusicianBookingSystem.Models;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(
    p => p.UseSqlServer(builder.Configuration.GetConnectionString("con")
));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Slot}/{action=Index}/{id?}");

app.Run();

