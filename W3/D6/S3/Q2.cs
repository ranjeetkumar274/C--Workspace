Linq 2:
 
using System.Resources;
using System.ComponentModel.DataAnnotations;
namespace dotnetapp.Models
{
    public class Student
    {
        [Key]
        public int StudentId {get;set;}
 
    [Required]
        [StringLength(100)]
        public string Name {get;set;}
 
    [Required]
        [EmailAddress]
        public string Email {get;set;}
 
    [Required]
        [Range(0,int.MaxValue)]
        public int YearOfJoining {get;set;}
        public int CourseId {get;set;}
        public Course Course{get;set;}
    }
}
 
 
Course.cs
 
using System.Collections;
using System.ComponentModel.DataAnnotations;
namespace dotnetapp.Models
{
    public class Course
    {
 
    [Key]
    public int CourseId {get;set;}
        [Required]
        [StringLength(100)]
        public string Title {get;set;}
        [Required]
        [StringLength(500)]
        public string Description{get;set;}
        public ICollection<Student> Students {get;set;}
    }
}
 
 
DbCOntext:
 
using Microsoft.EntityFrameworkCore;
namespace dotnetapp.Models
{
 
    public class AppDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder m)
        {
            m.Entity<Student>().
                    HasOne(c => c.Course).
                    WithMany(s => s.Students).
                    HasForeignKey(cou => cou.CourseId);
            m.Entity<Course>().HasData
            (
                    new Course
                    {
                        CourseId = 1,
                        Title = "Mathematics 101",
                        Description = "Basic Mathematics"
                    },
                    new Course
                    {
                        CourseId = 2,
                        Title = "History 101",
                        Description = "Introduction to History"
                    }
            );
        }
    }
 
}
 
 
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
    public class StudentController : Controller
    {
        public AppDbContext db;
        public StudentController(AppDbContext db1)
        {
            db = db1;
        }
 
    public IActionResult AddStudent()
        {
            // var cs = db.Courses.ToList();
            // ViewBag.Courses = new SelectList(cs,"CourseId","Title");
            return View();
        }
        [HttpPost]
        public IActionResult AddStudent(Student obj)
        {
 
    db.Students.Add(obj);
            db.SaveChanges();
            return RedirectToAction("DisplayAllStudents");
        }
        public IActionResult DisplayAllStudents()
        {
            var res = db.Students.Include(s=>s.Course).ToList();
            return View(res);
        }
        public IActionResult UpdateStudent(int id)
        {
            var res = db.Students.Find(id);
 
    return View(res);
        }
        [HttpPost]
        public IActionResult SearchStudentsByName(string name)
        {
            var res = db.Students.Where(s=>s.Name == name).ToList();
 
    return View(res);
        }
        public IActionResult UpdateStudent(Student obj)
        {
            var res = db.Students.Find(obj.StudentId);
            if(res!=null)
            {
                res.Name = obj.Name;
                res.Email = obj.Email;
                res.YearOfJoining = obj.YearOfJoining;
                res.CourseId = obj.CourseId;
                res.Course = obj.Course;
                db.SaveChanges();
                return RedirectToAction("DisplayAllStudents");
            }
            return View();
        }
    }
}
 
student controller
 
