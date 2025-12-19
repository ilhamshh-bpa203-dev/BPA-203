using System.ComponentModel.DataAnnotations.Schema;

namespace _34_Front_To_BackSqlConnection.Models
{
    public class Slider :BaseEntity
    {
        public string? ImageURL { get; set; }
        public string Title{ get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }

        [NotMapped]
        public IFormFile Photo { get; set; }
        
    }
}
