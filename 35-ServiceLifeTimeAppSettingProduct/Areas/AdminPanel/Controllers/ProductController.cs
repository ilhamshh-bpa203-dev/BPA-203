using _34_Front_To_BackSqlConnection.DAL;
using _34_Front_To_BackSqlConnection.Models;
using _35_ServiceLifeTimeAppSettingProduct.Areas.AdminPanel.ViewModels;
using _35_ServiceLifeTimeAppSettingProduct.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace _35_ServiceLifeTimeAppSettingProduct.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class ProductController : Controller
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
                    Price = p.Price,
                    CategoryName = p.Category.Name,
                    ImageURL = p.ProductImages.Where(p => p.IsPrimary == true).FirstOrDefault().ImageURL
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
                    .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null) return NotFound();

            GetProductVM getProductVM = new GetProductVM
            {
                Name = product.Name,
                Price = product.Price,
                CategoryName = product.Category.Name,
                ImageURL = product.ProductImages.FirstOrDefault().ImageURL
            };

            return View(getProductVM);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            List<Category> categories = await _context.Categories.ToListAsync();
            List<Tag> tags = await _context.Tags.ToListAsync();



            CreateProductVM createProductVM = new()
            {
                Categories = categories,
                Tags = tags
            };

            return View(createProductVM);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductVM createProductVM)
        {
            createProductVM.Categories = await _context.Categories.ToListAsync();
            createProductVM.Tags = await _context.Tags.ToListAsync();

            if (createProductVM.Price < 0)
            {
                ModelState.AddModelError(nameof(createProductVM.Price), "Price cant be negative");
                return View(createProductVM);
            }

            if (!ModelState.IsValid)
            {
                return View(createProductVM);
            }


           
                bool existsProduct = createProductVM.Categories.Any(c => c.Id == createProductVM.CategoryId);
                if (!existsProduct)
                {
                ModelState.AddModelError(nameof(CreateProductVM.CategoryId), "Category not exists");
                    return View(createProductVM);
                }



            if (createProductVM.TagIds is not null)
            {
                bool existsTag = createProductVM.TagIds.Any(tId => createProductVM.Tags.Exists(t => t.Id == tId));
                if (!existsProduct)
                {
                    ModelState.AddModelError(nameof(CreateProductVM.TagIds), "Tag not exists");
                    return View(createProductVM);
                }
            }


            Product product = new()
            {
                Name = createProductVM.Name,
                Price = createProductVM.Price.Value,
                SKU = createProductVM.SKU,
                Description = createProductVM.Description,
                CategoryId = createProductVM.CategoryId.Value,
            };


            if (createProductVM.TagIds is not null)
            {
             product.ProductTags = createProductVM.TagIds.Select(tId=>new ProductTag
             {
                 TagId = tId,
             }).ToList();   
            }


            await _context.Products.AddAsync(product);  
            await _context.SaveChangesAsync();


            return RedirectToAction(nameof(Index));

        }
        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            if (id is null || id < 1) return BadRequest();


            Product product = await _context.Products
                .Include(p=>p.ProductTags)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (product is null) return NotFound();

            UpdateProductVM updateProductVM = new UpdateProductVM()
            {
                Name = product.Name,
                Price = product.Price,
                SKU = product.SKU,
                Description = product.Description,
                CategoryId = product.CategoryId,
                Categories = await _context.Categories.ToListAsync(),
                Tags = await _context.Tags.ToListAsync(),
                TagIds = product.ProductTags.Select(pt=>pt.TagId).ToList(),
            };

            return View(updateProductVM);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int? id,UpdateProductVM updateProductVM)
        {
            if (id is null || id < 1) return BadRequest();

            updateProductVM.Categories = await _context.Categories.ToListAsync();


            if (!ModelState.IsValid)
            {
                return View(updateProductVM);
            }

            Product existsProduct = await _context.Products.FirstOrDefaultAsync(c => c.Id == id);
            if(existsProduct is null) return NotFound();

            if (updateProductVM.CategoryId != existsProduct.CategoryId)
            {
                bool isExistsCategory = updateProductVM.Categories.Any(c=>c.Id == updateProductVM.CategoryId);
                if (!isExistsCategory)
                {
                    ModelState.AddModelError(nameof(UpdateProductVM.CategoryId), "Category not exists");
                    return View(updateProductVM);
                }
            }

            existsProduct.Name = updateProductVM.Name;
            existsProduct.SKU = updateProductVM.SKU;
            existsProduct.CategoryId = updateProductVM.CategoryId.Value;
            existsProduct.Price = updateProductVM.Price.Value;
            existsProduct.Description = updateProductVM.Description;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }





    }
}
