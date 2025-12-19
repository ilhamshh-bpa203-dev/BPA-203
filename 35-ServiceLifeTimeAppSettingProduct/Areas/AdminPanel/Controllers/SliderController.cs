using _34_Front_To_BackSqlConnection.DAL;
using _34_Front_To_BackSqlConnection.Models;
using _35_ServiceLifeTimeAppSettingProduct.Models;
using _35_ServiceLifeTimeAppSettingProduct.Utilities.Enums;
using _35_ServiceLifeTimeAppSettingProduct.Utilities.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.ContentModel;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace _35_ServiceLifeTimeAppSettingProduct.Areas.AdminPanel.Controllers
{
    [Area("Adminpanel")]
    public class SliderController : Controller
    {
        private readonly AppDBContext _context;
        private readonly IWebHostEnvironment _env;

        public SliderController(AppDBContext context ,IWebHostEnvironment env )
        {
            _context = context;
            _env = env;
        }

        [Area("adminpanel")]
        public async Task<IActionResult> Index()
        {
            List<Slider> sliders = await _context.Sliders.ToListAsync();

            return View(sliders);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id is null || id < 1) return BadRequest();


            Slider slider = await _context.Sliders
                .FirstOrDefaultAsync(c => c.Id == id);

            if (slider is null) return NotFound();

            return View(slider);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Slider slider)
        {
            if (slider.ImageURL is null)
            {
                ModelState.AddModelError(nameof(slider.ImageURL), "Image cant be empty");
                return View();
            }

            if (!slider.Photo.CheckFileType("image/")) {
                ModelState.AddModelError(nameof(slider.Photo), "File type is incorrect");
                return View(slider);
            }
            if (!slider.Photo.CheckFieSize(FileSize.MB,2)) 
            {
                ModelState.AddModelError(nameof(slider.Photo), "File size must be less then 2mb");
                return View(slider);
            }

            slider.ImageURL = await slider.Photo.CreateFileAsync(_env.WebRootPath, "assets", "images","website-images");

            if (!ModelState.IsValid) return View();

            await _context.Sliders.AddAsync(slider);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id) 
        {
            if (id is null || id < 1) return BadRequest();


            Slider slider = await _context.Sliders
                .FirstOrDefaultAsync(c => c.Id == id);

            if (slider is null) return NotFound();


            slider.ImageURL.DeleteFile(_env.WebRootPath, "assets", "images", "website-images");

            System.IO.File.Delete(slider.ImageURL);


            _context.Sliders.Remove(slider);
            await _context.SaveChangesAsync();



            return RedirectToAction(nameof(Index));
        }



    }
}
