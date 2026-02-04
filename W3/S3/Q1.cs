// ProductController.cs

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using dotnetapp.Models;

namespace dotnetapp.Controllers
{
    // [Route("[controller]")]
    public class ProductController : Controller
    {
        public AppDbContext db {get;set;}
        public ProductController(AppDbContext db1){
            db=db1;
        }
        public IActionResult DisplayAllProducts(){
        var res = db.Products.Include(a=>a.Category).ToList();
        return View(res);
    }
    public IActionResult AddProduct(Product obj){
        db.Products.Add(obj);
        db.SaveChanges();
        return View();
    }
    }

}



// AppDbContext.cs


using Microsoft.EntityFrameworkCore;

namespace dotnetapp.Models
{

    //Write AppDbContext here...
    public class AppDbContext : DbContext{
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){

    }
        public DbSet<Category> Categories{get;set;}
        public DbSet<Product> Products{get;set;}
        protected override void OnModelCreating(ModelBuilder m){
            m.Entity<Product>()
                .HasOne(p=>p.Category)
                .WithMany(c=>c.Products)
                .HasForeignKey(p=>p.CategoryId);

    m.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = 1,
                    Name="Electronics",
                    Description="Very Good"
                }
            );
        }
    }
}



// Category.cs


using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace dotnetapp.Models
{
    // Write your Category class here...
    public class Category{

    [Key]
        public int CategoryId{get;set;}

    [Required]
        [StringLength (100)]
        public string Name{get;set;}

    [StringLength (500)]
        public string Description{get;set;}
        public ICollection<Product> Products {get;set;} = new List<Product>();
    }
}



// Product.cs



using System.ComponentModel.DataAnnotations;
namespace dotnetapp.Models
{
    // Write your Product class here...
    public class Product{
        [Key]
        public int ProductId{get;set;}
        [Required]
        public string Name{get;set;}
        public decimal Price{get;set;}
        public int Stock {get;set;}
        public int CategoryId{get;set;}
        public Category Category{get;set;}
    }
}



// Program.cs

using dotnetapp.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options=>options.UseSqlServer("user id=sa;password=examlyMssql@123;server=localhost;database=appdb;trusted_connection=false;Persist Security Info=false;Encrypt=false"));

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
    pattern: "{controller=Product}/{action=DisplayAllProducts}/{id?}");

app.Run();



// AddProduct.cshtml


@model dotnetapp.Models.Product

@{
    ViewData["Title"] = "Add Product";
}

<h2>Add New Product</h2>

<form asp-action="AddProduct" method="post">
    <div class="form-group">
        <label asp-for="Name" class="control-label">Name:</label>
        <input asp-for="Name" class="form-control" />
        <span asp-validation-for="Name" class="text-danger"></span>
    </div>
    <div class="form-group">
        <label asp-for="Price" class="control-label">Price:</label>
        <input asp-for="Price" class="form-control" />
        <span asp-validation-for="Price" class="text-danger"></span>
    </div>
    <div class="form-group">
        <label asp-for="Stock" class="control-label">Stock:</label>
        <input asp-for="Stock" class="form-control" />
        <span asp-validation-for="Stock" class="text-danger"></span>
    </div>
    <div class="form-group">
        <label asp-for="CategoryId" class="control-label">Category:</label>
        <select asp-for="CategoryId" class="form-control" asp-items="ViewBag.Categories"></select>
        <span asp-validation-for="CategoryId" class="text-danger"></span>
    </div>
    <button type="submit" class="btn btn-primary">Add Product</button>
</form>



// DisplayAllProduct.cshtml


@model List<dotnetapp.Models.Product>

<p>
    <a asp-action="AddProduct" class="btn btn-primary">Add Product</a>
</p>

<h2>All Products</h2>

<table class="table">
    <thead>
        <tr>
            <th>Name</th>
            <th>Price</th>
            <th>Stock</th>
            <th>Category</th>
        </tr>
    </thead>
    <tbody>
        @foreach (var product in Model)
        {
            <tr>
                <td>@product.Name</td>
                <td>@product.Price</td>
                <td>@product.Stock</td>
                <td>@product.Category?.Name</td>
            </tr>
        }
    </tbody>
</table>
