using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace AspNetMvcRoles.Models
{
    [NotMapped]
    public class Erro : IdentityErrorDescriber
    {
        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError()
            {

                Code = nameof(PasswordRequiresUpper),
                Description = "A Senha deve Conter pelo menos uma Letra Maiúscula"
            };
        }

        public override IdentityError PasswordRequiresNonAlphanumeric()
        {

            return new IdentityError()
            {

                Code = nameof(PasswordRequiresNonAlphanumeric),
                Description = "As senhas devem ter pelo menos um caractere não alfanumérico."
            };

        }


        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError()
            {

                Code = nameof(PasswordRequiresLower),
                Description = "As senhas devem ter pelo menos uma letra minúscula('a' - 'z')."
            };
        }
    }
}
