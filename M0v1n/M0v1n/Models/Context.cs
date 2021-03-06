﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace M0v1n.Models
{
    public class Context : DbContext
    {
        public Context() : base("M0v1n")
        {
            Configuration.ProxyCreationEnabled = false;
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Context>());
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Locador> Locadores { get; set; }
        public DbSet<Avaliar> Avaliacoes { get; set; }
        public DbSet<Anuncio> Anuncios { get; set; }
        public DbSet<Cancelar> Cancelacao { get; set; }
        public DbSet<Administrador> Administradores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}