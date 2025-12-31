using _34_Front_To_BackSqlConnection.Models;

namespace _35_ServiceLifeTimeAppSettingProduct.Models
{
    public class Size : BaseEntity
    {
        public string Name { get; set; }

        public List<ProductSize> ProductSizes { get; set; }
    }
}
