using System;

namespace Persistencia.Database.Models
{
    class Pedido
    {
        public int Id { get; set; }
        public string NombreCliente { get; set; }
        public int CantPizza { get; set; }
        public DateTime FechaPedido { get; set; }
        public DateTime HoraPedido { get; set; }
        public int DemoraEstimada { get; set; }
        public int Estado { get; set; }


    }
}
