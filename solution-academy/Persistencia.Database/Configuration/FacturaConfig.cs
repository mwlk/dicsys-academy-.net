using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistencia.Database.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistencia.Database.Configuration
{
    class FacturaConfig
    {
        public FacturaConfig(EntityTypeBuilder<Factura> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Total).IsRequired().HasMaxLength(4);
            builder.Property(x => x.FechaHoraEmision).IsRequired();
        }
    }
}
