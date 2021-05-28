using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

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
    }
}
