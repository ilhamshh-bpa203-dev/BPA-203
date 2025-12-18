using _34_Front_To_BackSqlConnection.DAL;
using _34_Front_To_BackSqlConnection.Models;
using _35_ServiceLifeTimeAppSettingProduct.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _35_ServiceLifeTimeAppSettingProduct.Areas.AdminPanel.Controllers
{
    [Area("Adminpanel")]
    public class SliderController : Controller
    {
        private readonly AppDBContext _context;

        public SliderController(AppDBContext context)
        {
            _context = context;
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

    }
}
