using _34_Front_To_BackSqlConnection.DAL;
using _35_ServiceLifeTimeAppSettingProduct.Areas.AdminPanel.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace _35_ServiceLifeTimeAppSettingProduct.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class ProductController:Controller
    {
        private readonly AppDBContext _context;
        private readonly IWebHostEnvironment _env;

        public ProductController(AppDBContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            List<GetProductVM> getProductVMs = await _context.Products
                .Include(p => p.ProductImages)
                .Include(p => p.Category)
                .Select(p => new GetProductVM
                {
                    Name = p.Name,
                    Price= p.Price,
                    CategoryName=p.Category.Name,
                    ImageURL = p.ProductImages.FirstOrDefault().ImageURL
                })
                .ToListAsync();


            return View(getProductVMs);
        }


    }
}
