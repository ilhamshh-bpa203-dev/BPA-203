using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace _32_WebApplication.Controllers
{
    public class HomeController:Controller
    {

        public IActionResult Index()
        {
            return View();

        }

        public IActionResult? Detail(int? id)
        {
            if (id is null || id < 1)
            {
                return RedirectToAction(nameof (Error));
            }

            return RedirectToAction("Index","Product");
        }
        public IActionResult Error()
        {
            return View();
        }

    }
}
