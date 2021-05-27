using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebCRUDApp.Models.Entidades
{
    public class Cargo
    {
        [Key]
        public int CargoId { get; set; }
        [StringLength(40, MinimumLength = 2)]
        [Required(ErrorMessage = "O Cargo é obrigatório!")]
        [Display(Name ="Cargo")]
        public string NomeCargo { get; set; }

        public IEnumerable<Pessoas> Pessoa { get; set; }

    }
}
