Validation 2q
Data/ApplicationDbContext.cs
using dotnetapp.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
 
namespace dotnetapp.Data
{
 
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){ }
        public DbSet<Customer> Customers{get;set;}
    }
}
 
 
 
Models/Customer.cs
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
namespace dotnetapp.Models
{
 
    public class Customer
    {
        public int CustomerId{get;set;}
       
       
        [Required(ErrorMessage="First name is required")]
        public string FirstName{get;set;}
       
       
        [Required(ErrorMessage="Last name is required")]
        public string LastName{get;set;}
       
        [Required(ErrorMessage="Email is required")]
        [EmailAddress]
        [UniqueEmail]
        public string Email{get;set;}
       
        [RegularExpression(@"^(\+\d{1,3}\s?)?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$", ErrorMessage="Invalid phone number format.")]
        public string PhoneNumber{get;set;}
 
        [MinAge(25)]
        [DataType(DataType.Date)]
        public DateTime BirthDate{get;set;}
       
       
        [Required(ErrorMessage="Address is required")]
        public string Address{get;set;}
    }
 
}
 
 
Models/UniqueEmailAttribute
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using dotnetapp.Data;
 
namespace dotnetapp.Models
{
    public class UniqueEmailAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var _context = (ApplicationDbContext)validationContext.GetService(typeof(ApplicationDbContext));
            if(_context==null)
            {
                return ValidationResult.Success;
            }
            var email = value.ToString();
            var customer = _context.Customers.FirstOrDefault(c=> c.Email == email);
 
            if(customer != null)
            {
                return new ValidationResult(ErrorMessage ?? "Email must be unique");
            }
            return ValidationResult.Success;
        }
    }
}
 
Models/MinAgeAttribute.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetapp.Data;
using System.ComponentModel.DataAnnotations;
 
namespace dotnetapp.Models
{
    public class MinAgeAttribute: ValidationAttribute
    {
        private readonly int _minAge;
        public MinAgeAttribute(int minAge)
        {
            _minAge = minAge;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value!=null)
            {
                DateTime birthDate = (DateTime)(value);
                int age = DateTime.Today.Year - birthDate.Year;
                if(birthDate > DateTime.Today.AddYears(-age)) age--;
                if(age <_minAge)
                {
                    return new ValidationResult(ErrorMessage ?? $"Customer must be {_minAge} years or older");
                }
            }
            return ValidationResult.Success;
        }
    }
}
 
CustomerController.cs
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using dotnetapp.Data;
using dotnetapp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
 
namespace dotnetapp.Controllers
{
    // [Route("[controller]")]
    public class CustomerController : Controller
    {
        public readonly ApplicationDbContext db;
        public CustomerController(ApplicationDbContext db1){ db=db1; }
 
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
 
        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            if(!ModelState.IsValid)
            {
                ModelState.AddModelError("FirstName","First name is required.");
                ModelState.AddModelError("LastName","Last name is required.");
            }
            if(ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Success");
            }
            return View(customer);
        }
 
        public IActionResult Success()
        {
            ViewBag.Message = "Customer created successfully";
            return View();
        }
    }
}
