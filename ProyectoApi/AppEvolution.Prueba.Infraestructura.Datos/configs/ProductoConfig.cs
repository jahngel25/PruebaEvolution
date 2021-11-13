using System;
using System.Collections.Generic;
using System.Text;

using AppEvolution.Prueba.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppEvolution.Prueba.Infraestructura.Datos.configs
{
    class ProductoConfig : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.ToTable("Producto");
            builder.HasKey(c => c.ProID);
        }
    }
}
