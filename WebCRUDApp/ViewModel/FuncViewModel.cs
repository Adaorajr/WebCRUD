using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using WebCRUDApp.Models.Entidades;

namespace WebCRUDApp.ViewModel
{
    [Keyless]
    public class FuncViewModel
    {   
        public int Id { get; set; }   //clase pessoa
        public string Nome { get; set; }       
        public string Sobrenome { get; set; }
        [Display(Name = "Nascimento")]    
        [DataType(DataType.Date, ErrorMessage="Data em formato inválido")]       
        public DateTime DataNascimento { get; set; }
        [Display(Name = "Cargo")]
        [Required(ErrorMessage ="O Cargo é Obrigatório!")]
        public string NomeCargo { get; set; }
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

        //public virtual Endereco endereco { get; set; }
    }
}
