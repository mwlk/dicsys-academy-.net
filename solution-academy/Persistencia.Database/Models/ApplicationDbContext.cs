using Microsoft.EntityFrameworkCore;
using Persistencia.Database.Configuration;

namespace Persistencia.Database.Models
{
    class ApplicationDbContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=localhost;Initial Catalog=Pizzeria;Integrated Security = True");
        }

        public  virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<DetallePedido> DetallePedidos { get; set; }
        public  virtual DbSet<Factura> Facturas { get; set; }
        public virtual DbSet<Ingrediente> Ingredientes { get; set; }
        public virtual DbSet<Pedido> Pedidos { get; set; }
        public virtual DbSet<Pizza> Pizzas { get; set; }
        public virtual DbSet<TipoPizza> TipoPizzas { get; set; }
        public virtual DbSet<VariedadPizza> VariedadPizzas { get; set; }


        protected override void OnModelCreating(ModelBuilder model)
        {
            new PedidoConfig(model.Entity<Pedido>());
            new ClienteConfig(model.Entity<Cliente>());
            new DetallePedidoConfig(model.Entity<DetallePedido>());
            new FacturaConfig(model.Entity<Factura>());
            new IngredienteConfig(model.Entity<Ingrediente>());
            new PizzaConfig(model.Entity<Pizza>());
            new TipoPizzaConfig(model.Entity<TipoPizza>());
            new VariedadPizzaConfig(model.Entity<VariedadPizza>());

            base.OnModelCreating(model);
        }





    }
}
