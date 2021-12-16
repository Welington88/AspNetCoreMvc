using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ApsNet.Models;

namespace ApsNet.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApsNet.Models.Cargo> Cargo { get; set; }
        public DbSet<ApsNet.Models.Setor> Setor { get; set; }
        public DbSet<ApsNet.Models.Funcinario> Funcinario { get; set; }
    }
}
