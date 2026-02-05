// MusicRecordController.cs

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using dotnetapp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using dotnetapp.Models;

using Microsoft.EntityFrameworkCore;

namespace dotnetapp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MusicRecordController : ControllerBase
    {
       public ApplicationDbContext cont;

       public MusicRecordController(ApplicationDbContext context){
        cont = context;
       }

       [HttpGet]
       public async Task<IActionResult> GetMusicRecords(){
        var list = cont.MusicRecords.ToList();
        if(list.Count <= 0){
            return NoContent();
        }
        return Ok(list);
       }

       [HttpGet("{id}")]
       public async Task<IActionResult> GetMusicRecord(int id){
        var item = cont.MusicRecords.Find(id);
        if(item == null){
            return NotFound();
        }
        return Ok(item);
       }

       [HttpPost]
       public async Task<IActionResult> CreateMusicRecord([FromBody] MusicRecord mr){
        if(mr.OrderId == null){
            return BadRequest("No OrderID");
        }
        cont.MusicRecords.Add(mr);
        cont.SaveChanges();
        return CreatedAtAction("CreateMusicRecord",mr);
       }


       [HttpPut("{id}")]
       public async Task<IActionResult> UpdateMusicRecord(int id, MusicRecord mr){
        var res = cont.MusicRecords.Find(id);
        if(res == null){
            return NotFound();
        }
        res.Artist = mr.Artist;
        res.Album = mr.Album;
        res.Genre = mr.Genre;
        res.Price = mr.Price;
        res.StockQuantity = mr.StockQuantity;
        res.OrderId = mr.OrderId;

        cont.SaveChanges();
        return NoContent();
       }


       [HttpDelete("{id}")]
       public async Task<IActionResult> DeleteMusicRecord(int id){
        var res = cont.MusicRecords.Find(id);
        if(res == null){
            return NotFound();
        }
        cont.MusicRecords.Remove(res);
        cont.SaveChanges();
        return NoContent();
       }
    }
}



// OrderController.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetapp.Data;
using dotnetapp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dotnetapp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {

        public ApplicationDbContext cont;

        public OrderController(ApplicationDbContext context){
            cont = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetOrders(){
            var list = cont.Orders.ToList();
            if(list.Count <= 0){
                return NoContent();
            }
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetOrder(int id){
            var res = cont.Orders.Find(id);
            if(res == null){
            return NotFound();
        }
            return Ok(res);
        }


        [HttpPost]
        public async Task<ActionResult> CreateOrder(Order or){
            cont.Orders.Add(or);
            cont.SaveChanges();
            return CreatedAtAction("CreateOrder",or);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateOrder(int id, Order o){
            var res = cont.Orders.Find(id);
            if(res == null){
            return NotFound();
        }
            res.CustomerName = o.CustomerName;
            res.OrderDate = o.OrderDate;
            cont.SaveChanges();
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOrder(int id){
            var res = cont.Orders.Find(id);
            if(res == null){
            return NotFound();
        }
            cont.Orders.Remove(res);
            cont.SaveChanges();
            return NoContent();
        }
    }
}



// AppDbContext.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetapp.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnetapp.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> ops):base(ops){}

        public DbSet<MusicRecord> MusicRecords{get; set;}
        public DbSet<Order> Orders{get; set;}
    }
}



// MusicRecord.cs

namespace dotnetapp.Models
{
    public class MusicRecord{
    public int MusicRecordId {get; set;}
    public string Artist {get; set;}
    public string Album{get ; set;}
    public string Genre{get; set;}
    public decimal Price{get; set;}
    public int StockQuantity {get ;set;}
    public int? OrderId {get; set;}
    public Order? Order{get; set;}
    }
    
}



// Order.cs


using System.Collections;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace dotnetapp.Models
{
    public class Order{
        public int OrderId{get; set;}
        public string CustomerName{get; set;}
        public string OrderDate{get; set;}

        [JsonIgnore]
        public ICollection<MusicRecord>? MusicRecords{get; set;} =new List<MusicRecord>();
    }
}






// Program.cs


    using Microsoft.EntityFrameworkCore;
    using dotnetapp.Data;


    var builder = WebApplication.CreateBuilder(args);

    // Add Event services to the container.

    builder.Services.AddControllers();
    builder.Services.AddDbContext<ApplicationDbContext>(
        t => t.UseSqlServer(builder.Configuration.GetConnectionString("con"))
    );

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
