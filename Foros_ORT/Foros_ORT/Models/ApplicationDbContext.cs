using System;
using System.Collections.Generic;
using System.Text;
using Foros_ORT.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Foros_ORT
{
    public class ApplicationDbContext : IdentityDbContext<Usuario>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Foro> Foros { get; set; }
        public DbSet<Posteo> Posteos { get; set; }
        public DbSet<Respuesta> Respuestas { get; set; }
    }
}
