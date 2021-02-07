using System;

namespace Persistencia.Database.Models
{
    class Factura
    {
        public int Id { get; set; }
        public float Total { get; set; }
        public DateTime FechaHoraEmision { get; set; }

        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; }
        
    }
}
