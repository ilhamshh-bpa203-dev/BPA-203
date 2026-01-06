using System.ComponentModel.DataAnnotations;

namespace _35_ServiceLifeTimeAppSettingProduct.ViewModels
{
    public class RegisterVM
    {
        [MaxLength(20)]
        [MinLength(3)]
        
        public string Name{ get; set; }
        [MaxLength(20)]
        [MinLength(3)]
        public string Surname{ get; set; }
        [MaxLength(50)]
        [MinLength(4)]
        public string Username{ get; set; }
        [MaxLength(50)]
        [DataType(DataType.EmailAddress)]//kohne usul
        //[EmailAddress]//yeni usul
        public string Email{ get; set; }
        [DataType(DataType.Password)]
        public string Password{ get; set; }
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword{ get; set; }
    }
}
