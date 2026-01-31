using Project3.Models;
using Project3.Exceptions;
using Microsoft.AspNetCore.Mvc;


namespace Project3.Controllers
{
    public class EmployeeController : Controller
    {
        public EmpDbContext cont;

        public EmployeeController(EmpDbContext context)
        {
            cont = context;
        }

        public async Task<ActionResult> ShowAll()
        {
            var list = cont.Employees.ToList();
            return View(list);
        }

        public async Task<ActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Add(Employee e)
        {
            if (ModelState.IsValid)
            {
                if(e.Salary < 10000 || e.Salary > 200000)
                {
                    throw new InvalidSalaryExc("Salary must in Range.");
                }

                cont.Employees.Add(e);
                cont.SaveChanges();
                return RedirectToAction("ShowAll");
            }
            return View(e);
        }
    }
}