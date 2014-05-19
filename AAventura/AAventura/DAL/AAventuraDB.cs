using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace AAventura.DAL
{
    public class AAventuraDB : DbContext
    {
        public DbSet<Utilizador> Utilizadores { get; set; }
        public DbSet<Score> Scores { get; set; }
        public DbSet<Aventura> Aventuras { get; set; }
        public DbSet<Zona> Zonas { get; set; }
        public DbSet<Pergunta> Perguntas { get; set; }
        public DbSet<Hipotese> Hipoteses { get; set; }
        public DbSet<Item> Itens { get; set; }

       protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
       