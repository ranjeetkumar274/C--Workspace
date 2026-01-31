using Microsoft.AspNetCore.Mvc;
using GymPass.Models;

namespace GymPass.Controllers
{
    public class PassController: Controller
    {
        public PassDbContext cont;

        public PassController(PassDbContext context)
        {
            cont = context;
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Pass p)
        {
            if (ModelState.IsValid)
            {
                cont.Passes.Add(p);
                cont.SaveChanges();
                return RedirectToAction("ShowAll");
            }
            return View(p);
        }


        public IActionResult ShowAll()
        {
           var list = cont.Passes.ToList();
           return View(list);
        }

    }
}