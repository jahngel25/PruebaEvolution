using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using AppEvolution.Prueba.Dominio.Entidades;
using AppEvolution.Prueba.Infraestructura.Datos.configs;

namespace AppEvolution.Prueba.Infraestructura.Datos.Contextos
{    

    public class PruebaEvolutionContexto : DbContext
    {
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=A6ZPH5CG91230N2\LOCALHOST;Database=PruebaEvolution;uid=sa;password=Agosto2021*;");

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new PedidoConfig());
            builder.ApplyConfiguration(new ProductoConfig());
            builder.ApplyConfiguration(new UsuarioConfig());

        }
    }
}
