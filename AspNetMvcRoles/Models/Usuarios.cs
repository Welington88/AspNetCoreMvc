using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AspNetMvcRoles.Models
{
    [Table("Cadastro")]
    public class Usuarios
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = " O Campo {0} é Obrigatório!")]
        public String Nome { get; set; }

        [Required(ErrorMessage = " O Campo {0} é Obrigatório!")]
        [DataType(DataType.EmailAddress)]
        [StringLength(50)]
        [RegularExpression(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])",
            ErrorMessage = "Seu email não está no formato correto!")]
        public String Usuario { get; set; }

        [Required(ErrorMessage = " O Campo {0} é Obrigatório!")]
        [StringLength(50, ErrorMessage = " O Campo {0} pode ter no máximo {1} e minimo {2} caracteres ", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public String Senha { get; set; }

        [Required(ErrorMessage = " O Campo {0} é Obrigatório!")]
        public bool Ativo { get; set; }

        [Required(ErrorMessage = " O Campo {0} é Obrigatório!")]
        public String Nivel { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        [NotMapped]
        public bool Root  { get; set; }
    }
}
