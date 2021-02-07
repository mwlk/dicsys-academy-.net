﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistencia.Database.Models;

namespace Persistencia.Database.Configuration
{
    class PedidoConfig
    {
       public PedidoConfig(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasKey(x => x.Id);
            //builder.Property(x => x.NombreCliente).IsRequired().HasMaxLength(40); va por idCliente
            builder.Property(x => x.FechaHoraPedido).IsRequired();
            builder.Property(x => x.DemoraEstimada).HasMaxLength(2);
            //suponiendo que la demora no va a ser > a 60 min
            builder.Property(x => x.Estado).HasMaxLength(1);
            builder.Property(x => x.Total).IsRequired().HasMaxLength(4);
        }
    }
}
