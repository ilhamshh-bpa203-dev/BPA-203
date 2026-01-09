using _34_Front_To_BackSqlConnection.DAL;
using _35_ServiceLifeTimeAppSettingProduct.Models;
using _35_ServiceLifeTimeAppSettingProduct.Utilities.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _35_ServiceLifeTimeAppSettingProduct.ViewComponents
{
    public class ProductViewComponent : ViewComponent
    {
        private readonly AppDBContext _context;

        public ProductViewComponent(AppDBContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(SortType sortType)
        {

            List<Product> products = null;
            switch (sortType)
            {
                case SortType.Name:
                    products = await _context.Products
                        .OrderBy (x => x.Name)  
                       .Include(p => p.ProductImages.Where(pi => pi.IsPrimary != null))
                      .ToListAsync(); 
                    break;
                case SortType.Price:
                    products = await _context.Products
                        .OrderByDescending (x => x.Price)
                       .Include(p => p.ProductImages.Where(pi => pi.IsPrimary != null))
                      .ToListAsync(); 
                    break;
                case SortType.Date:
                    products = await _context.Products
                        .OrderByDescending(x => x.CreatedAt)
                       .Include(p => p.ProductImages.Where(pi => pi.IsPrimary != null))
                      .ToListAsync(); 
                    break;

            }

            return View(products);
        }

    }
}
