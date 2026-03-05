using eVote360.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eVote360.Persistence.Context
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Ciudadano> Ciudadanos { get; set; }
        public DbSet<Partido> Partidos { get; set; }
        public DbSet<Puesto> Puestos { get; set; }
        public DbSet<Candidato> Candidatos { get; set; }
        public DbSet<Eleccion> Elecciones { get; set; }
        public DbSet<Voto> Votos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

       
        
    }
}

