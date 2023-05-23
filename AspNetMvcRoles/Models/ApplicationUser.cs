using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace AspNetMvcRoles.Models
{
    [NotMapped]
    public class ApplicationUser : IdentityUser
    {
        [Required(ErrorMessage = " O Campo {0} é Obrigatório!")]
        public override string Email { get => base.Email; set => base.Email = value; }
    }
}
