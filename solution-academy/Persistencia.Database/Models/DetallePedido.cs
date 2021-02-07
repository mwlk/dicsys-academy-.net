using System.Collections.Generic;

namespace Persistencia.Database.Models
{
    class DetallePedido
    {
        public int Id { get; set; }
        public int CantidadPizza { get; set; }
        //public float Precio { get; set; } //calcula en Pizza 
        public int PizzaId { get; set; }

        public List<Pizza> Pizzas { get; set; }
        public Pedido Pedido { get; set; }
    }
}
