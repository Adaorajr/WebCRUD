using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebCRUDApp.Models.Entidades
{
    public class FuncViewModel
    {
        
        public int FuncViewModelId { get; set; }        
        public string Nome { get; set; }       
        public string SobreNome { get; set; }
        [Display(Name = "Nascimento")]
        public string DataNascimento { get; set; }
        [Display(Name = "Cargo")]
        public string NomeCargo { get; set; }
        public int Id { get; set; }
      
    }
}
