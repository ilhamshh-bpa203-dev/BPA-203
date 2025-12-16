using Microsoft.AspNetCore.Mvc;

namespace _35_ServiceLifeTimeAppSettingProduct.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }



    }
}
