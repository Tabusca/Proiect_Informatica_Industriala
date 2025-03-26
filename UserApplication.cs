namespace ProiectV2.Models
{
    public class UserApplication
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public bool RememberMe { get; set; } = false;
        public DateTime CreatedAt { get; set; }
         


    }

}

