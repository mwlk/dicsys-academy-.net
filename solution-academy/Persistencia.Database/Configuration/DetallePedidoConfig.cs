using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistencia.Database.Models;

namespace Persistencia.Database.Configuration
{
    class DetallePedidoConfig
    {
        public DetallePedidoConfig(EntityTypeBuilder<DetallePedido> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Cantidad).IsRequired().HasMaxLength(2);
            builder.Property(x => x.Tipo).IsRequired().HasMaxLength(1);
            builder.Property(x => x.Tamanho).IsRequired().HasMaxLength(1);
            builder.Property(x => x.Subtotal).IsRequired();
        }
    }
}
