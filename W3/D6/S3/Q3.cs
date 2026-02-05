linq3
 
 
LibraryController
 
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using dotnetapp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
namespace dotnetapp.Controllers
{
    // [Route("[controller]")]
    public class LibraryController : Controller
    {
        AppDbContext _context;
        public LibraryController(AppDbContext db1){_context=db1;}
        public IActionResult DisplayAllBooks()
        {
            var res = _context.Books.Include(b=> b.LibraryCard).ToList();
            return View();
        }
        public IActionResult DisplayBooksForLibraryCard(int libraryCardId)
        {
            var res = _context.Books.FirstOrDefault(b=> b.LibraryCardId == libraryCardId);
            return View(res);
        }
        public IActionResult SearchBooksByTitle(string query)
        {
            var res = _context.Books.FirstOrDefault(b=> b.Title.ToLower() == query);
            return View(res);
        }
        public IActionResult AddBook()
        {
 
    return View();
        }
        public IActionResult AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
            return RedirectToAction("DisplayAllBooks");
        }
        public IActionResult DeleteBook(int id)
        {
            var res = _context.Books.FirstOrDefault(b=> b.Id == id);
            if(res!=null)
            {
                _context.Books.Remove(res);
                _context.SaveChanges();
                return RedirectToAction("DisplayAllBooks");
            }
            return NotFound();
        }
    }
}
 
 
AppDbContext:
 
using Microsoft.EntityFrameworkCore;
namespace dotnetapp.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<LibraryCard> LibraryCards { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder m)
        {
            m.Entity<Book>().
            HasOne(b => b.LibraryCard).
            WithMany(l => l.Books).
            HasForeignKey(lb => lb.LibraryCardId).
            IsRequired(false);
 
            m.Entity<LibraryCard>().HasData
                                (
                                        new LibraryCard
                                        {
                                            Id = 1,
                                            CardNumber = "LC-12345",
                                            MemberName = "John Doe",
                                            ExpiryDate = new DateTime(2025, 12, 31)
                                        },
                                        new LibraryCard
                                        {
                                            Id = 2,
                                            CardNumber = "LC-54321",
                                            MemberName = "Jane Smith",
                                            ExpiryDate = new DateTime(2024, 10, 15)
                                        }
                );
        }
    }
}
 
 
Book.cs
 
using System.ComponentModel.DataAnnotations;
 
namespace dotnetapp.Models
{
    public class Book
    {
        public int Id{get;set;}
        [Required]
        [StringLength(100)]
        public string Title{get;set;}
        [Required]
        [StringLength(50)]
        public string Author{get;set;}
        [Required]
        [Range(1000,2024)]
        public int PublishedYear{get;set;}
        public int? LibraryCardId{get;set;}
 
    public LibraryCard LibraryCard {get; set;}
    }
}
 
 
LibraryCard.cs
 
using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
namespace dotnetapp.Models
{
    public class LibraryCard
    {
        public int? Id{get;set;}
        [Required]
        [RegularExpression(@"LC-\d{5}")]
        public string CardNumber{get;set;}
        [Required]
        [StringLength(50)]
        public string MemberName{get;set;}
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime ExpiryDate{get;set;}
        public ICollection <Book> Books{get;set;}
    }
}
