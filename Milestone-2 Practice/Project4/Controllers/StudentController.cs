using Microsoft.AspNetCore.Mvc;
using Project4.Models;
using Project4.Exceptions;

namespace Project4.Controllers
{
    public class StudentController : Controller
    {
        public AppDbContext cont;

        public StudentController(AppDbContext context)
        {
            cont = context;
        }

        public async Task<ActionResult> ShowAll()
        {
            var list = cont.Students.ToList();
            return View(list);
        }

        public async Task<ActionResult> Add()
        {
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> Add(Student std)
        {
            if (ModelState.IsValid)
            {
                if(std.GPA > 4.0 && std.GPA < 0.0)
                {
                    throw new GpaRangeException("Enter a valid GPA.");
                }
                if(std.Year > 4 && std.Year < 1)
                {
                    throw new GpaRangeException("Enter a valid Year.");
                }
                cont.Students.Add(std);
                cont.SaveChanges();
                return RedirectToAction("ShowAll");
            }
            return View(std);
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            var list = cont.Students.ToList();
            var o = list.Find(a => a.StudentID == id);
            if(o == null)
            {
                return NotFound();
            }
            return View(o);
        }

        [HttpPost]
        [ActionName("Delete")]
         public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var o = cont.Students.Find(id);
            if(o == null)
            {
                return View();
            }
            cont.Students.Remove(o);
            cont.SaveChanges(); 
            return RedirectToAction("ShowAll");
        }



        
    }
}