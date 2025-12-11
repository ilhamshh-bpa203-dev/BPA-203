using _34_Front_To_BackSqlConnection.DAL;
using _34_Front_To_BackSqlConnection.Models;
using _34_Front_To_BackSqlConnection.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace _34_Front_To_BackSqlConnection.Controllers
{
    public class HomeController : Controller
    {
       private readonly AppDBContext _context;
        public HomeController(AppDBContext context)
        {
         _context = context;    
        }






        public IActionResult Index()
        {
            //_context.Sliders.AddRange(sliders);
            //_context.SaveChanges();

            List<Slider> sliders = _context.Sliders.ToList();

            HomeVM homeVM = new HomeVM
            {
                Sliders = sliders
            };

            return View(homeVM);
        }
    }
}
