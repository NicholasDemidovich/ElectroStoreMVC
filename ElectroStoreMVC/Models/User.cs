using Microsoft.AspNetCore.Identity;

namespace ElectroStoreMVC.Models
{
    public class User : IdentityUser
    {
        public string Address { get; set; }

        public string FullName { get; set; }
    }
}
