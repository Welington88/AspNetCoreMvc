using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApsNet.Models
{
    [Table("Funcionario")]
    public class Funcinario
    {
        public Funcinario()
        {
        }
        [Key]
        public int Matricula { get; set; }

        [Required]
        public String Nome { get; set; }
        
        public Boolean Gestor { get; set; }

        [ForeignKey("Setor")]
        public int IdSetor { get; set; }
        public virtual Setor Setor { get; set; }

        [ForeignKey("Cargo")]
        public int IdCargo { get; set; }
        public virtual Cargo Cargo { get; set; }


    }
}
