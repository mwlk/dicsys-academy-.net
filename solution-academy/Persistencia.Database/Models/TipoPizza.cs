namespace Persistencia.Database.Models
{
    class TipoPizza
    {
        //(a la piedra, a la parrilla, de molde)
        public int Id { get; set; }
        public string Nombre { get; set; }

        public Pizza Pizza { get; set; }
    }
}
