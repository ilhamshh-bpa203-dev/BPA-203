using System.ComponentModel.DataAnnotations.Schema;

namespace _35_ServiceLifeTimeAppSettingProduct.Areas.AdminPanel.ViewModels
{
    public class SliderUpdateVM
    {
        public string ImageURL { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }
        public IFormFile? Photo { get; set; }


    }
}
