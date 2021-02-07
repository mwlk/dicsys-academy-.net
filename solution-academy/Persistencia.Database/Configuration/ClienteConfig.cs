using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistencia.Database.Models;

namespace Persistencia.Database.Configuration
{
    class ClienteConfig
    {
        public ClienteConfig(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nombre).IsRequired().HasMaxLength(20);
            builder.Property(x => x.Apellido).HasMaxLength(20);
            builder.Property(x => x.NroTelefono).HasMaxLength(15);
        }
    }
}
