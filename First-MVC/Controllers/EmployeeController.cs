using First_MVC.Models.Data;
using First_MVC.Models.Entities;
using First_MVC.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace First_MVC.Controllers
{
    public class EmployeeController : Controller
    {
        AppDBContext Context = new AppDBContext();

        public IActionResult Details(int id)
        {
            string msg = "Hello From Action";
            int temp = 45;
            List<string> Branches = new List<string>();
            Branches.Add("Alex");
            Branches.Add("Mansoura");
            Branches.Add("Cairo");
            //Additional Infos ==>
            ViewData["Msg"] = msg;
            ViewData["Temp"] = temp;
            ViewData["Branches"] = Branches;
            ViewBag.Color = "Blue";

            Employee EmployeeModel = Context.Employee.FirstOrDefault(x => x.Id == id);
            return View("Details", EmployeeModel);
        }
        public IActionResult DetailsVM(int id)
        {
            Employee empModel = Context.Employee
                .Include(e=>e.Department)
                .FirstOrDefault(x => x.Id == id);
            List<string> Branches = new List<string>();
            Branches.Add("Alex");
            Branches.Add("Mansoura");
            Branches.Add("Cairo");
            //declare ViewModel
            EmpDeptColorTempMsgBrchViewModel EmpVm =
                new EmpDeptColorTempMsgBrchViewModel();
            //Mapping
            EmpVm.EmpName = empModel.Name;
            EmpVm.DeptName = empModel.Department.Name;
            EmpVm.Msg = "Hello From VM";
            EmpVm.Color = "Blue";
            EmpVm.Branches = Branches;

            return View("DetailsVM", EmpVm);// type==>EmpDeptColorTempMsgBrchViewModel
        }
    }
}
