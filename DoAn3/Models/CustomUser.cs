using Microsoft.AspNetCore.Identity;

namespace DoAn3.Models
{
    public class CustomUser : IdentityUser
    {
        public string FullName { get; set; } = "";
        public int Age { get; set; } = 20;
    }
}
