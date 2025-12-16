using _34_Front_To_BackSqlConnection.DAL;
using _35_ServiceLifeTimeAppSettingProduct.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace _35_ServiceLifeTimeAppSettingProduct.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class CategoryController : Controller
    {
        private readonly AppDBContext _context;

        public CategoryController(AppDBContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<Category> categories =await _context.Categories
                .Include(c=>c.Products)
                .Where(c=>c.IsDeleted == false)
                .ToListAsync();

            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {

            if (!ModelState.IsValid)
            {
                return View();

            }

            bool existsCategory = await _context.Categories.AnyAsync(c=>c.Name.Trim()==category.Name.Trim());

            if (existsCategory)
            {
                ModelState.AddModelError("Name", "Category already exists");
                return View();
            }

            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();


            return RedirectToAction(nameof(Index));
        }

    }
}
