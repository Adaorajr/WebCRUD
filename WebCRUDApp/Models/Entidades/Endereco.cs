using System.ComponentModel.DataAnnotations;

namespace WebCRUDApp.Models.Entidades
{
    public class Endereco
    {
        [Key]
        public int id { get; set; }
        [Display(Name = "CEP")]
        public string cep { get; set; }
        [Display(Name = "Logradouro")]
        public string logradouro { get; set; }
        [Display(Name = "Número")]
        public int numero { get; set; }
        [Display(Name = "Complemento")]
        public string complemento { get; set; }
        [Display(Name = "Bairro")]
        public string bairro { get; set; }
        [Display(Name = "UF")]
        public string uf { get; set; }
    }
}
