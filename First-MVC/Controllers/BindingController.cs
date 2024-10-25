using Microsoft.AspNetCore.Mvc;

namespace First_MVC.Controllers
{
    public class BindingController : Controller
    {
        //Request HTML (data)
        //Binidion Primitive (int, string ...
        public IActionResult TestPrimitive
            (string Name , int age, int id, string[] color)
        {
            return Content($"{Name} : {id} {age}");
        }
        public IActionResult TestDic(Dictionary<string,string> Phones)
        {
            return View("OK");
        }
    }
}
