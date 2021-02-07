using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistencia.Database.Models;

namespace Persistencia.Database.Configuration
{
    class DetallePedidoConfig
    {
        public DetallePedidoConfig(EntityTypeBuilder<DetallePedido> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CantidadPizza).IsRequired();

        }
    }
}
