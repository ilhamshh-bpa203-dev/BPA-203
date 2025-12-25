using _35_ServiceLifeTimeAppSettingProduct.Models;
using System.ComponentModel.DataAnnotations;

namespace _35_ServiceLifeTimeAppSettingProduct.Areas.AdminPanel.ViewModels
{
    public class UpdateProductVM
    {
        public string Name { get; set; }

        [Required]
        public decimal? Price { get; set; }
        public string Description { get; set; }
        public string SKU { get; set; }
        [Required]
        public int? CategoryId { get; set; }
        public List<Category>? Categories { get; set; }
        public List<int>? TagIds { get; set; }
        public List<Tag>? Tags { get; set; }
    }
}
