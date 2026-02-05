using Microsoft.AspNetCore.Mvc;
using Project5.Models;
using Project5.Exceptions;



namespace Project5.Controllers
{
    public class BookController : Controller
    {
        public AppDbContext cont;

        public BookController(AppDbContext context)
        {
            cont = context;
        }

        public async Task<ActionResult> AvailableBooks()
        {
            var v = cont.Books.ToList();
            return View(v);
        }

        public async Task<ActionResult> AddBook()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddBook(Book b)
        {
            if (ModelState.IsValid)
            {
                if(b.AvailableCopies < 0 && b.AvailableCopies > 10)
                {
                    throw new BookAvailabilityException("Invalid Numbers of Copies.");
                }
                cont.Books.Add(b);
                cont.SaveChanges();
                return RedirectToAction("AvailableBooks");
            }
            return View(b);
        }

        public async Task<ActionResult> Delete(int id)
        {
            var v = cont.Books.Find(id);
            if(v == null)
            {
                return NotFound("No Book Avaialble");
            }
            cont.Books.Remove(v);
            cont.SaveChanges();
            return RedirectToAction("AvailableBooks");
        }


    }
}