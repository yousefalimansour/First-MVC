using First_MVC.Models.Data;
using First_MVC.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace First_MVC.Controllers
{
    public class DepartmentController : Controller
    {
        AppDBContext Context = new AppDBContext();
        public IActionResult Index()
        {
            List<Department> departmentList =
                Context.Department.ToList();
            return View("Index", departmentList);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View("Add");
        }
        [HttpPost]
        public IActionResult SaveAdd(Department deptfromrequest)
        {
            if (deptfromrequest.Name != null)
            {
                Context.Department.Add(deptfromrequest);
                Context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Add",deptfromrequest);
        }
    }
}
