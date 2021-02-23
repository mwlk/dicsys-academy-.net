using System;

namespace Persistencia.Database.Models
{
    public class Factura
    {
        public int Id { get; set; }
        public int FormaPago { get; set; }
        public int PedidoId { get; set; }

        public Pedido Pedido { get; set; }
        
    }
}
