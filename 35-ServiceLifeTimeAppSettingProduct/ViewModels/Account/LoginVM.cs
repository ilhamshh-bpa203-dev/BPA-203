using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace _35_ServiceLifeTimeAppSettingProduct.ViewModels
{
    public class LoginVM
    {
        [MinLength(4)]
        [MaxLength(40)]
        public string UsernameOrEmail { get; set; }
        [MinLength(8)]
        [PasswordPropertyText]
        public string Password { get; set; }
        public bool IsPersistent { get; set; }
    }
}
