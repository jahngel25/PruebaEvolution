using System;
using System.Collections.Generic;
using System.Text;

using AppEvolution.Prueba.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppEvolution.Prueba.Infraestructura.Datos.configs
{
    class PedidoConfig : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedido");
            builder.HasKey(c => c.PedID);
        }
    }
}
