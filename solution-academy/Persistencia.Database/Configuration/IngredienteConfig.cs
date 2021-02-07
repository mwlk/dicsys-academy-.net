using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistencia.Database.Models;

namespace Persistencia.Database.Configuration
{
    class IngredienteConfig
    {
        public IngredienteConfig(EntityTypeBuilder<Ingrediente> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nombre).IsRequired().HasMaxLength(20);
        }
    }
}
