using _34_Front_To_BackSqlConnection.Models;
using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace _35_ServiceLifeTimeAppSettingProduct.Models
{
    public class Category:BaseEntity
    {
        //[Required (ErrorMessage ="Bos olmaz")]
        [MaxLength(25, ErrorMessage=" Category cant be more than 20 ") ]
        public  string Name{ get; set; }
        public List<Product>? Products { get; set; }
    }
}
