using _34_Front_To_BackSqlConnection.DAL;
using _35_ServiceLifeTimeAppSettingProduct.Areas.AdminPanel.ViewModels;
using _35_ServiceLifeTimeAppSettingProduct.Models;
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
                    Id = p.Id,
                    Name = p.Name,
                    Price= p.Price,
                    CategoryName=p.Category.Name,
                    ImageURL = p.ProductImages.FirstOrDefault().ImageURL
                })
                .ToListAsync();


            return View(getProductVMs);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {

            if (id is null || id < 1) return BadRequest();
            
            Product product = await _context.Products
                    .Include(p => p.Category)
                    .Include(p => p.ProductImages)  
                    .FirstOrDefaultAsync(p=>p.Id == id);

            if (product == null) return NotFound();

            GetProductVM getProductVM = new GetProductVM
            {
                Name= product.Name,
                Price= product.Price,   
                CategoryName= product.Category.Name,
                ImageURL = product.ProductImages.FirstOrDefault().ImageURL
            };

            return View(getProductVM);
        }


    }
}
