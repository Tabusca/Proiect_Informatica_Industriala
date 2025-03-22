using Microsoft.AspNetCore.Identity;

namespace proiect.Models
{
    public class Users : IdentityUser
    {
        public string FullName { get; set; }
    }
}
