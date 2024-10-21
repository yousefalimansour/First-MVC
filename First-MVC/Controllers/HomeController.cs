using First_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace First_MVC.Controllers
{
    public class HomeController : Controller
    {
        /*Constrains for Creating Methods in Home Page 
         1) Method Public 
         2) Can not be Static
         3) Can not be overload
        */

        public ContentResult ShowMsg()
        {
           //declare
           ContentResult result = new ContentResult();
           //Initial
           result.Content = "Hello World";
           //return
           return result;
        }
        public ViewResult ShowView()
        {
            ViewResult result = new ViewResult();
            result.ViewName = "View1";
            return result;
        }

         public IActionResult ShowMix(int id )
        {
            if (id % 2 == 0)
            {                
                return View("View1");
            }
            else
            {               
                return Content("Hello World");
            }
        }
        








        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
