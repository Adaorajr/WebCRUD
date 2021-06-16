using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


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
        [Required(ErrorMessage = "O Sobrenome é obrigatório!")]
        public string Sobrenome { get; set; }
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime DataNascimento { get; set; }
        [ForeignKey("CargoId")]
        public int CargoId { get; set; }       
        public virtual Cargo Cargo{ get; set; }
        public virtual Endereco endereco { get; set; }
    }
}
