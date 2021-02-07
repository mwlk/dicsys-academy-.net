using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistencia.Database.Models;

namespace Persistencia.Database.Configuration
{
    class TipoPizzaConfig
    {
        public TipoPizzaConfig(EntityTypeBuilder<TipoPizza> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nombre).IsRequired().HasMaxLength(20);
        }

    }
}
