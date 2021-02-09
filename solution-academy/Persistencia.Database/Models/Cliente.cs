using System.Collections.Generic;

namespace Persistencia.Database.Models
{
    class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string? NroTelefono { get; set; }

        public List<Pedido> Pedidos { get; set; }
        
    }
}
