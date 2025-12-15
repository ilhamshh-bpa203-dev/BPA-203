using _34_Front_To_BackSqlConnection.DAL;
using _35_ServiceLifeTimeAppSettingProduct.Models;
using _35_ServiceLifeTimeAppSettingProduct.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _34_Front_To_BackSqlConnection.Controllers
{
    public class ShopController : Controller
    {
        private readonly AppDBContext _context;

        public ShopController(AppDBContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || id < 1) return BadRequest();

            Product? product = await _context.Products
                .Include(p=>p.Category)
                .Include(p=>p.ProductImages)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null) return NotFound();


            List<Product> relatedProduct = _context.Products
                .Where(pi => pi.CategoryId == product.CategoryId && pi.Id != product.Id)
                .Include(p=>p.ProductImages.Where(pi=>pi.IsPrimary != null ))
                .ToList();


            ShopVM shopVM = new ShopVM
            {
                Product = product,
                RelatedProducts = relatedProduct,
            };

            return View(shopVM);
        }

    }
}
