using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project6.Data;
using Project6.Models;
using Microsoft.AspNetCore.Mvc;

namespace Project6.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ApplicationDbContext cont;

        public OrderController(ApplicationDbContext context)
        {
            cont = context;
        }


        [HttpGet]
        public IActionResult GetOrders()
        {
            var list = cont.Orders.ToList();
            return Ok(list);
        }


        [HttpGet("{id}")]
        public IActionResult GetOrder(int id)
        {
            var res = cont.Orders.Find(id);
            return Ok(res);
        }


        [HttpPost]
        public IActionResult CreateOrder([FromBody] Order or)
        {
            cont.Orders.Add(or);
            cont.SaveChanges();
            return CreatedAtAction(nameof(GetOrder), new { id = or.OrderId }, or);
        }


        [HttpPut("{id}")]
        public IActionResult UpdateOrder(int id, [FromBody] Order o)
        {
            var res = cont.Orders.Find(id);
            res.CustomerName = o.CustomerName;
            res.OrderDate = o.OrderDate;
            cont.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            var res = cont.Orders.Find(id);
            if (res == null) return NotFound();
            cont.Orders.Remove(res);
            cont.SaveChanges();
            return Ok(res);
        }
    }
}