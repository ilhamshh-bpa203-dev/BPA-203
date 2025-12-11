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
            //_context.Shippings.AddRange(shippings);
            //_context.SaveChanges();

            List<Slider> sliders = _context.Sliders.ToList();
            List<Shipping> shippings = _context.Shippings.ToList();
            List<Client> clients = _context.Clients.ToList();

            HomeVM homeVM = new HomeVM
            {
                Sliders = sliders,
                Shippings = shippings,
                Clients = clients

            };

            return View(homeVM);
        }
    }
}
