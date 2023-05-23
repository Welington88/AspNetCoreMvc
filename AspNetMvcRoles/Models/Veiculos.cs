using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetMvcRoles.Models {
    [Table("VeiculosHunter")]
    public class Veiculos
    {
        [Key]
        public int Id { get; set; }

        public string Modelo { get; set; }

        public string Montadora { get; set; }
    }

}