using System;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreMvc.Models
{
    public class Pessoa
    {
        [Key]
        public int IdPessoa { get; set; }
        
        public String Nome { get; set; }

        public int Qtd { get; set; }
    }
}