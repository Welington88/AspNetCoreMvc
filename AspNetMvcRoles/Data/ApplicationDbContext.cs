using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AspNetMvcRoles.Models;

namespace AspNetMvcRoles.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Cargo> Cargo { get; set; }
        public DbSet<Funcinario> Funcinario { get; set; }
        public DbSet<Setor> Setor { get; set; }
        public DbSet<Sedes> Sedes { get; set; }
        public DbSet<Regras> Regras { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<AspNetMvcRoles.Models.Veiculos> Veiculo { get; set; }
    }
}
