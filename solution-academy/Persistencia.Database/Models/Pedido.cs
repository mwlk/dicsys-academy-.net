using System;
using System.Collections.Generic;

namespace Persistencia.Database.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public string NombreCliente { get; set; }
        public DateTime FechaHoraPedido { get; set; }
        public int DemoraEstimada { get; set; }
        public int Estado { get; set; }
        

        public Factura Factura { get; set; }
        public List<DetallePedido> DetallePedidos { get; set; }


    }
}
