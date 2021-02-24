using Persistencia.Database.Models;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class PizzaService
    {
        public List<Pizza> GetAll()
        {
            using ApplicationDbContext db = new ApplicationDbContext();
            var list = db.Pizzas.ToList();
            return list;
        }
        public void Create() { }
        
        public void GetFavoritePizza() { }
    }
}
