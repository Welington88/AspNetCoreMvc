using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AspNetMvcRoles.Models
{
    [Table("Sedes_Empresa")]
    public class Sedes
    {
        public Sedes()
        {
        }

        [Key]
        public int IdSede { get; set; }

        [Display(Name = "Descrição Sede")]
        [Column("Descr_Sede", TypeName = "varchar(50)")]
        [Required(ErrorMessage = " O Campo {0} é Obrigatório!")]
        [StringLength(50, ErrorMessage = " O Campo {0} pode ter no máximo {1} e minimo {2} caracteres ", MinimumLength = 2)]
        public String Descricao { get; set; }

        [Display(Name = "É Alugada?")]
        [Required(ErrorMessage = " O Campo {0} é Obrigatório!")]
        public bool Aluguel { get; set; }

        [Display(Name = "Data da Abertura")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy h:m}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = " O Campo {0} é Obrigatório!")]
        public DateTime DataAbertura { get; set; }

        [Display(Name = "Valor da Sede")]
        [Required(ErrorMessage = " O Campo {0} é Obrigatório!")]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Currency)]
        public Decimal ValorDaSede { get; set; }

        [JsonIgnore]
        public virtual ICollection<Setor> Setores { get; set; }
    }
}
