using System.Collections.Generic;

namespace Persistencia.Database.Models
{
    class Pizza
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public float Precio { get; set; }
        public int TipoPizzaId { get; set; }
        public int VariedadPizzaId { get; set; }

        public List<Ingrediente> Ingredientes { get; set; }
        public VariedadPizza VariedadPizza { get; set; }
        public TipoPizza TipoPizza { get; set; }
    }
}
