using System.ComponentModel.DataAnnotations;

namespace proiect.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Numele de utilizator este obligatoriu.")]
        [EmailAddress(ErrorMessage = "Numele de utilizator trebuie să fie o adresă de email validă.")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Parola este obligatorie.")]
        [MinLength(6, ErrorMessage = "Parola trebuie să conțină cel puțin 6 caractere.")]
        public string Password { get; set; } = string.Empty;

        public bool RememberMe { get; set; }
    }
}
