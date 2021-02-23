using System.Collections.Generic;

namespace Persistencia.Database.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public float Precio { get; set; }

        public List<Ingrediente> Ingredientes { get; set; }
       
    }
}
