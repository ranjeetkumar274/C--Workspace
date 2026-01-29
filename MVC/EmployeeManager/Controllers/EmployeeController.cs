using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using EmployeeManager.Models;

namespace EmployeeManager.Controllers
{

    public class EmployeeController : Controller{
    
    public static List<Employee> list = new List<Employee>();

    public ActionResult Index()
    {
        return View(list);
    }

    public ActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Add(Employee emp)
    {
        if (ModelState.IsValid)
        {
            list.Add(emp);
            return RedirectToAction("ShowAll");

        }
        return View();
    }


    public ActionResult ShowAll()
        {
            return View(list);
        }
}
}