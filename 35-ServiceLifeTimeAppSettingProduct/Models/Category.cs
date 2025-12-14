using _34_Front_To_BackSqlConnection.Models;

namespace _35_ServiceLifeTimeAppSettingProduct.Models
{
    public class Category:BaseEntity
    {
        public  string Name{ get; set; }
        public List<Product> Products { get; set; }
    }
}
