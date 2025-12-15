using _34_Front_To_BackSqlConnection.DAL;
using _34_Front_To_BackSqlConnection.Models;
using _34_Front_To_BackSqlConnection.ViewModels;
using _35_ServiceLifeTimeAppSettingProduct.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            List<Product> products = _context.Products
                .Include(p => p.ProductImages.Where(pi=>pi.IsPrimary != null))
                .ToList();


            HomeVM homeVM = new HomeVM
            {
                Sliders = sliders,
                Shippings = shippings,
                Clients = clients,
                Products = products,

            };

            return View(homeVM);
        }
    }
}
