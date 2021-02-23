using System.Collections.Generic;

namespace Persistencia.Database.Models
{
    public class DetallePedido
    {
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public int PizzaId { get; set; }
        public int Cantidad { get; set; }
        public float Subtotal { get; set; }
        public int  Tipo { get; set; }
        public int Tamanho { get; set; }

        public Pizza Pizza { get; set; }
        public Pedido Pedido { get; set; }
    }
}
