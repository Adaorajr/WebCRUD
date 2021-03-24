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
        [StringLength(40, MinimumLength =2)]
        [Required(ErrorMessage ="O Nome é obrigatório!")]
        public string Nome { get; set; }
        [StringLength(40, MinimumLength = 2)]
        [Required(ErrorMessage = "O SobreNome é obrigatório!")]
        public string SobreNome { get; set; }
        //[DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]       
        [Display(Name = "Data Nascimento")]
        [Required(ErrorMessage ="A data de Nascimento é obrigatória!")]      
        public string DataNascimento { get; set; }
        public int CargoId { get; set; }       

        
        [ForeignKey("CargoId")]
        public Cargo Cargo{ get; set; }
       
        
    }

}
