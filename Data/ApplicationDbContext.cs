using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ApsNet.Models;
using AspNetCoreMvc.Models;

namespace ApsNet.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}

        public DbSet<Cargo> Cargo { get; set; }
        public DbSet<Setor> Setor { get; set; }
        public DbSet<Funcinario> Funcinario { get; set; }
        public DbSet<Pessoa> Pessoa { get; set; }
    }
}
