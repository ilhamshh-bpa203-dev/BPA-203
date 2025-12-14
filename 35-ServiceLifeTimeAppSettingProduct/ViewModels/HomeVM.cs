using _34_Front_To_BackSqlConnection.Models;
using _35_ServiceLifeTimeAppSettingProduct.Models;

namespace _34_Front_To_BackSqlConnection.ViewModels
{
    public class HomeVM
    {
        public List<Slider> Sliders { get; set; }
        public List<Shipping> Shippings { get; set; }
       public List<Client> Clients { get; set; }
        public List<Product> Products { get; set; }
    }
}
