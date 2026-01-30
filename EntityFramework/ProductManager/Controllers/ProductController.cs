using Microsoft.AspNetCore.Mvc;
using ProductManager.Models;
namespace ProductManager.controllers
{
    public class ProductController : Controller
    {

        public static ProductDbContext cont;

        public ProductController(ProductDbContext context)
        {
            cont = context;
        }
        public ActionResult Index()
        {
            var products = cont.Products.ToList();
            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Show()
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Create(Product p)
        {
            if (ModelState.IsValid)
            {
                cont.Products.Add(p);
                cont.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(p);
        }
    }
}