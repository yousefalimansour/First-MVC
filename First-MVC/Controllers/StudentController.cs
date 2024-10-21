using First_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace First_MVC.Controllers
{
    public class StudentController : Controller
    {
      //Student/ShowAll
      public IActionResult ShowAll()
        {
            StudentBL studentbl = new StudentBL();
            List<Student> studentsModel = studentbl.GetAll();
            return View("ShowAll", studentsModel);
        }

        public IActionResult Details(int id)
        {
            StudentBL studentByID = new StudentBL();
            Student ByID =studentByID.GetByID(id);
            return View("ShowDetails", ByID);
        }
    }
}
