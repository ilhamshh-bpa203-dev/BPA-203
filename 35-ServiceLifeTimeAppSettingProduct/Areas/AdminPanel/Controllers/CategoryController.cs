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


        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            if (id is null || id < 1) return BadRequest();

            Category existsCategory = await _context.Categories
                .FirstOrDefaultAsync(c=>c.Id == id);

            if (existsCategory is null) return NotFound();



            return View(existsCategory);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int? id,Category category)
        {
            if (id is null || id < 1) return BadRequest();

            Category existsCategory = await _context.Categories.AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);

            if (existsCategory is null) return NotFound();

            if (!ModelState.IsValid)
            {
                return View();
            }

            bool isExistsCategory = await _context.Categories
                .AnyAsync(c=>c.Name.Trim() == category.Name.Trim() && c.Id != category.Id);

            if (isExistsCategory)
            {
                ModelState.AddModelError(nameof(category.Name), "Category already Exists");
                return View();
            }

            existsCategory.Name = category.Name;

            _context.Categories.Update(existsCategory);
            
            await  _context.SaveChangesAsync();


            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null || id < 1) return BadRequest();

            Category existsCategory = await _context.Categories
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);

            if (existsCategory is null) return NotFound();

            //if (!existsCategory.IsDeleted)
            //{
            //    existsCategory.IsDeleted = true;
            //}
            //else
            //{

            //    existsCategory.IsDeleted = false;
            //} 

            existsCategory.IsDeleted = true;

            _context.Categories.Update(existsCategory);

            //Hard delete
            //_context.Categories.Remove(existsCategory);

            

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id is null || id < 1) return BadRequest();


            Category categories = await _context.Categories
                .Include(c => c.Products)
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();
           
            if (categories is null) return NotFound();

            return View(categories);
        }


    }
}
