using _34_Front_To_BackSqlConnection.DAL;
using _34_Front_To_BackSqlConnection.Models;
using _35_ServiceLifeTimeAppSettingProduct.Areas.AdminPanel.ViewModels;
using _35_ServiceLifeTimeAppSettingProduct.Models;
using _35_ServiceLifeTimeAppSettingProduct.Utilities.Enums;
using _35_ServiceLifeTimeAppSettingProduct.Utilities.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.ContentModel;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace _35_ServiceLifeTimeAppSettingProduct.Areas.AdminPanel.Controllers
{
    [Area("Adminpanel")]
    [Authorize("Admin,Moderator,Member")]
    public class SliderController : Controller
    {
        private readonly AppDBContext _context;
        private readonly IWebHostEnvironment _env;

        public SliderController(AppDBContext context ,IWebHostEnvironment env )
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            List<SliderGetVM> sliderVMs = await _context.Sliders
                .Select(s=>new SliderGetVM
                {
                    Id = s.Id,
                    Title = s.Title,
                    ImageURL= s.ImageURL,
                    Order = s.Order,
                })
                .ToListAsync();



            return View(sliderVMs);
        }


        [Authorize("Admin,Moderator")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id is null || id < 1) return BadRequest();


            Slider slider = await _context.Sliders
                .FirstOrDefaultAsync(c => c.Id == id);

            if (slider is null) return NotFound();

            SliderDetailsVM sliderDetailsVM = new()
            {
                Id = slider.Id,
                Title = slider.Title,
                ImageURL = slider.ImageURL,
                Order = slider.Order,
                SubTitle = slider.SubTitle,
                Description = slider.Description,
            };


            return View(sliderDetailsVM);
        }



        [Authorize("Admin,Moderator")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SliderCreateVM sliderCreateVM)
        {

            if (!ModelState.IsValid) return View();

          

            if (!sliderCreateVM.Photo.CheckFileType("image/")) {
                ModelState.AddModelError(nameof(sliderCreateVM.Photo), "File type is incorrect");
                return View(sliderCreateVM);
            }
            if (!sliderCreateVM.Photo.CheckFieSize(FileSize.MB,2)) 
            {
                ModelState.AddModelError(nameof(sliderCreateVM.Photo), "File size must be less then 2mb");
                return View(sliderCreateVM);
            }
            Slider slider = new Slider 
            {
             Title= sliderCreateVM.Title,
             SubTitle= sliderCreateVM.SubTitle,
             Description= sliderCreateVM.Description,
             Order= sliderCreateVM.Order,
             ImageURL = await sliderCreateVM.Photo.CreateFileAsync(_env.WebRootPath, "assets", "images", "website-images")

            };




            await _context.Sliders.AddAsync(slider);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        [Authorize("Admin,Moderator")]
        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            if (id is null || id < 1) return BadRequest();


            Slider slider = await _context.Sliders
                .FirstOrDefaultAsync(c => c.Id == id);

            if (slider is null) return NotFound();

            SliderUpdateVM sliderVM = new SliderUpdateVM
            {
                ImageURL = slider.ImageURL,
                Title = slider.Title,
                SubTitle=slider.SubTitle,
                Description= slider.Description,
                Order= slider.Order,

            };




            return View(sliderVM);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int? id,SliderUpdateVM sliderUpdateVM)
        {

            if (!ModelState.IsValid) return View(sliderUpdateVM);

            Slider slider = await _context.Sliders
                .FirstOrDefaultAsync(c => c.Id == id);

            if (slider is null) return NotFound();

            if (sliderUpdateVM.Photo != null)
            {
                if (!sliderUpdateVM.Photo.CheckFileType("image/"))
                {
                    ModelState.AddModelError(nameof(sliderUpdateVM.Photo), "File type is incorrect");
                    return View(sliderUpdateVM);
                }
                if (!sliderUpdateVM.Photo.CheckFieSize(FileSize.MB, 2))
                {
                    ModelState.AddModelError(nameof(sliderUpdateVM.Photo), "File size must be less then 2mb");
                    return View(sliderUpdateVM);
                }
                string fileName = await sliderUpdateVM.Photo.CreateFileAsync(_env.WebRootPath, "assets", "images", "website-images");

                slider.ImageURL.DeleteFile(_env.WebRootPath, "assets", "images", "website-images");

                slider.ImageURL = fileName;

            }

            slider.Title = sliderUpdateVM.Title;
            slider.Description = sliderUpdateVM.Description;
            slider.SubTitle = sliderUpdateVM.SubTitle;
            slider.Order = sliderUpdateVM.Order;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        [Authorize("Admin")]
        public async Task<IActionResult> Delete(int? id) 
        {
            if (id is null || id < 1) return BadRequest();


            Slider slider = await _context.Sliders
                .FirstOrDefaultAsync(c => c.Id == id);

            if (slider is null) return NotFound();

            slider.ImageURL.DeleteFile(_env.WebRootPath, "assets", "images", "website-images");

            //System.IO.File.Delete(slider.ImageURL);

            _context.Sliders.Remove(slider);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}
