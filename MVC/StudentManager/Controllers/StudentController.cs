using System.ComponentModel.Design;
using StudentManager.Models;
using Microsoft.AspNetCore.Mvc;


namespace StudentManager.Controllers
{

public class StudentController : Controller
{
    private static List<Student> list = new List<Student>();
    private static int nextId = 1;

    public ActionResult ShowAll()
    {
        return View(list);
    }

    // Add (GET)
    public ActionResult Add()
    {
        return View();
    }



    // Add (POST)
    [HttpPost]
    public ActionResult Add(Student std)
    {
        if (ModelState.IsValid)
        {
            std.StudentId = nextId++;
            list.Add(std);
            return RedirectToAction("ShowAll");
        }
        return View();
    }


    public ActionResult UpdateStudent(int id)
        {
            var res = list.Find(a => a.StudentId == id);
            if(res == null)
            {
                return NotFound();
            }
            return View(res);
        }


    [HttpPost]
    public ActionResult UpdateStudent(Student newStd)
        {
            var res = list.Find(a => a.StudentId == newStd.StudentId);
            if(res == null)
            {
                return NotFound();
            }
            res.StudentName = newStd.StudentName;
            res.Age = newStd.Age;
            res.Email = newStd.Email;

            return RedirectToAction("ShowAll");
        }

}
}