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

        public override IdentityError DefaultError()
        {
            return new IdentityError()
            {

                Code = nameof(DefaultError),
                Description = "Erro desconhecido."
            };
        }

        public override IdentityError InvalidUserName(string userName)
        {
            return new IdentityError()
            {

                Code = nameof(InvalidUserName),
                Description = "Nome de usuário inválido, apenas letras ou dígitos são permitidos."
            };
        }

        public override IdentityError PasswordMismatch()
        {
            return new IdentityError()
            {

                Code = nameof(PasswordMismatch),
                Description = "A senha está incorreta."
            };
        }
        public override IdentityError InvalidEmail(string email)
        {
            return new IdentityError()
            {

                Code = nameof(InvalidEmail),
                Description = "Endereço de e-mail inválido."
            };
        }
    }
}
