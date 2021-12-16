using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApsNet.Models
{
    [Table("Cargo")]
    public class Cargo
    {
        public Cargo()
        {
        }
        [Key]
        public int IdCargo { get; set; }
        [Display(Name ="Cargo")]
        public String Descricao { get; set; }

        [JsonIgnore]
        [ForeignKey("CargoRefId")]
        public virtual ICollection<Funcinario> Colaboradores { get; set; }
    }
}
