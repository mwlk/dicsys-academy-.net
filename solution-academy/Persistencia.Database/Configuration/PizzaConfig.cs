using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistencia.Database.Models;

namespace Persistencia.Database.Configuration
{
    class PizzaConfig
    {
        public PizzaConfig(EntityTypeBuilder<Pizza> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nombre).IsRequired().HasMaxLength(15);
            builder.Property(x => x.Precio).IsRequired().HasMaxLength(3);
        }
    }
}
