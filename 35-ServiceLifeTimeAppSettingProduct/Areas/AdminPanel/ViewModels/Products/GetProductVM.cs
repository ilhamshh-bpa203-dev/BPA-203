using _35_ServiceLifeTimeAppSettingProduct.Models;

namespace _35_ServiceLifeTimeAppSettingProduct.Areas.AdminPanel.ViewModels
{
    public class GetProductVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string CategoryName { get; set; }
        public string ImageURL { get; set; }
    }
}
