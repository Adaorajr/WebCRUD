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
        public string Nome { get; set; }       
        public string SobreNome { get; set; }
        [Display(Name = "Nascimento")]
        public string DataNascimento { get; set; }
        [Display(Name = "Cargo")]
        public string NomeCargo { get; set; }
        public int Id { get; set; }
      
    }
}
