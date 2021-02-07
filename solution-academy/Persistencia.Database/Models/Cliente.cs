namespace Persistencia.Database.Models
{
    class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string? NroTelefono { get; set; }

        public Pedido Pedido { get; set; }
    }
}
