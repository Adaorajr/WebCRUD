using System.ComponentModel.DataAnnotations;

namespace WebCRUDApp.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage ="Digite sua Senha Corretamente")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Lembrar-me")]
        public bool RememberMe { get; set; }
    }
}
