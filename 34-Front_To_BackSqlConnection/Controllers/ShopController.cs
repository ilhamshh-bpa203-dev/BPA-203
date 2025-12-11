using Microsoft.AspNetCore.Mvc;

namespace _34_Front_To_BackSqlConnection.Controllers
{
    public class ShopController : Controller
    {
        [Route("shop-list-left-sidebar.html")]
        public IActionResult Index()
        {
            return View();
        }


    }
}
