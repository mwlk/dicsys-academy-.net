using System.Collections.Generic;

namespace Persistencia.Database.Models
{
    class Ingrediente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public List<Pizza> Pizzas { get; set; }
    }
}
