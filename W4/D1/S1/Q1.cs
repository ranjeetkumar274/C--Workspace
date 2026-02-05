//Menu Controller
 
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
 
namespace dotnetapp.Controllers
{
    // [Route("[controller]")]
    public class MenuController : Controller{
 
        [Route("menu/home")]
        public IActionResult Home(){
            return View();
        }
        [Route("menu/products")]
        public IActionResult Products(){
            return View();
        }
        [Route("menu/customers")]
        public IActionResult Customers(){
            return View();
        }
        [Route("menu/orders")]
        public IActionResult Orders(){
            return View();
        }
 
 
    }
 
 
   
}
 
 
 
//ErrorViewModel
 
namespace dotnetapp.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }
 
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
 
 
Views > Menu > .cshtml
 
//customer.cshtml
 
<h1>Customer</h1>
<a asp-action="Products">Products</a>
 
 
//order.cshtml
 
<h1>Orders</h1>
<a asp-action="Home">Home</a>
 
 
// product.cshtml
 
<h1>Productors</h1>
<a asp-action="Orders">Orders</a>
