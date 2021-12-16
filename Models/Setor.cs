using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApsNet.Models
{
    [Table("Setor")]
    public class Setor
    {
        public Setor(){
        }
        [Key]
        public int IdSetor { get; set; }

        [Display(Name ="Setor")]
        public String Descricao { get; set; }

        [JsonIgnore]
        [ForeignKey("SetorRefId")]
        public virtual ICollection<Funcinario> Colaboradores { get; set; }

    }
    
}