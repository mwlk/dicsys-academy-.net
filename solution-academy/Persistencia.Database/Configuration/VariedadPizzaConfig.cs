using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistencia.Database.Models;

namespace Persistencia.Database.Configuration
{
    class VariedadPizzaConfig
    {
        public VariedadPizzaConfig(EntityTypeBuilder<VariedadPizza> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Descripcion).HasMaxLength(20);
            builder.Property(x => x.CantidadPorcion).IsRequired();
        }
    }
}
