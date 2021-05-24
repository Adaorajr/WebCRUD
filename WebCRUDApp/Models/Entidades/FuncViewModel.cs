using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebCRUDApp.Models.Entidades
{
    [Keyless]
    public class FuncViewModel
    {   
        public int Id { get; set; }   //clase pessoa
        public string Nome { get; set; }       
        public string SobreNome { get; set; }
        [Display(Name = "Nascimento")]    
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date, ErrorMessage="Data em formato inválido")]       
        public DateTime DataNascimento { get; set; }
        [Display(Name = "Cargo")]
        [Required(ErrorMessage ="O Cargo é Obrigatório!")]
        public string NomeCargo { get; set; }
        
      
    }
}
