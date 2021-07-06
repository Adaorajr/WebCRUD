using System.ComponentModel.DataAnnotations;

namespace WebCRUDApp.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Informe o e-mail!")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage ="Informe a senha!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Lembrar-me")]
        public bool RememberMe { get; set; }
    }
}
