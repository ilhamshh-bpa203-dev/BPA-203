using Microsoft.AspNetCore.Identity;

namespace _35_ServiceLifeTimeAppSettingProduct.Models
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }

    }
}
