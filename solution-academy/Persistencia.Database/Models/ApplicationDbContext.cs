using Microsoft.EntityFrameworkCore;
using Persistencia.Database.Configuration;

namespace Persistencia.Database.Models
{
    public class ApplicationDbContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=NOT0096;Initial Catalog=Pizzeria;Integrated Security = True");
        }

        public virtual DbSet<DetallePedido> DetallePedidos { get; set; }
        public  virtual DbSet<Factura> Facturas { get; set; }
        public virtual DbSet<Ingrediente> Ingredientes { get; set; }
        public virtual DbSet<Pedido> Pedidos { get; set; }
        public virtual DbSet<Pizza> Pizzas { get; set; }
        

        protected override void OnModelCreating(ModelBuilder model)
        {
            new PedidoConfig(model.Entity<Pedido>());
            new DetallePedidoConfig(model.Entity<DetallePedido>());
            new FacturaConfig(model.Entity<Factura>());
            new IngredienteConfig(model.Entity<Ingrediente>());
            new PizzaConfig(model.Entity<Pizza>());
            

            base.OnModelCreating(model);
        }





    }
}
