using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebCRUDApp.Models;


namespace WebCRUDApp.Models.Entidades
{
   
    public class Pessoas
    {       
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string DataNascimento { get; set; }
        public int CargoId { get; set; }

        //[Required]
        [ForeignKey("CargoId")]
        public Cargo Cargo{ get; set; }
        //public string NomeCargo { get; set; }
        
    }

}
