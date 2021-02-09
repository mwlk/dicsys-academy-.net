using System;
using System.Collections.Generic;

namespace Persistencia.Database.Models
{
    class Pedido
    {
        public int Id { get; set; }
        //public string NombreCliente { get; set; }
        public DateTime FechaHoraPedido { get; set; }
        public int DemoraEstimada { get; set; }
        public int Estado { get; set; }
        public float Total { get; set; }
        public int ClienteId { get; set; }

        public Factura Factura { get; set; }
        public Cliente Cliente { get; set; }
        public List<DetallePedido> DetallePedidos { get; set; }


    }
}
