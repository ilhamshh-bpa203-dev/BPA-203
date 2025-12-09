using _33_WebApplication.Models;
using _33_WebApplication.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace _33_WebApplication.Controllers
{
    public class HomeController:Controller
    {

        List<Students> students = new List<Students> { 
        new Students { Id=1,Name= "Ilham", Age=19 },
        new Students { Id=2,Name= "Aise", Age=18 },
        };

        List<Teachers> teachers = new List<Teachers>
        {
            new Teachers { Id=2,Name="Said",Salary=2000 },
            new Teachers { Id=3,Name="Rasad",Salary=2000 },

        };


        public IActionResult Index()
        {
            //ViewBag.Students = students;
            //ViewData["Students"] = students;
            //TempData["Name"] = "Ilham";
            HomeVM homeVM = new HomeVM
            {
                Students = students,
                Teachers = teachers
            };


            return View(homeVM);
        }



        [Route("korporativ")]   
        public IActionResult CorporativeSales()
        {
            return View();
        }
    }
}
