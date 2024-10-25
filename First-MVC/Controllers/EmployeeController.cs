using First_MVC.Models.Data;
using First_MVC.Models.Entities;
using First_MVC.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace First_MVC.Controllers
{
    public class EmployeeController : Controller
    {
        AppDBContext Context = new AppDBContext();

        public IActionResult Index()
        {
            return View("Index",Context.Employee.ToList());
        }
        public IActionResult Edit(int id)
        {
            if (id != 0)
            {
                Employee Emp = Context.Employee
                    .First(i=>i.Id==id);
                return View("Edit", Emp);
            }
            else
            {
                return NotFound();
            }
        }
        public IActionResult SaveEdit(Employee empFromRequest,int id)
        {
            if (empFromRequest.Name is not null)
            {
                Employee EmpfromDB = Context.Employee
                    .FirstOrDefault(e => e.Id == id);
                if (EmpfromDB != null)
                {
                    EmpfromDB.Address = empFromRequest.Address;
                    EmpfromDB.Name = empFromRequest.Name;
                    EmpfromDB.Salary = empFromRequest.Salary;
                    EmpfromDB.JobTilte = empFromRequest.JobTilte;
                    EmpfromDB.ImageURL = empFromRequest.ImageURL;
                    EmpfromDB.DepartmentID = empFromRequest.DepartmentID;
                    Context.SaveChanges();
                }
                else
                {
                    return BadRequest();
                }

            }
            return View("Edit",empFromRequest);

        }





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
