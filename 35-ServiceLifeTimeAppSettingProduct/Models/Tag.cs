using _34_Front_To_BackSqlConnection.Models;

namespace _35_ServiceLifeTimeAppSettingProduct.Models
{
    public class Tag : BaseEntity
    {
        public string Name { get; set; }

        public List<ProductTag> ProductTags { get; set; }
    }
}
