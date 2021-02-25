using Microsoft.EntityFrameworkCore;
using Persistencia.Database.Models;
using System;
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
        public void Create(Pizza pizza) {
            using ApplicationDbContext db = new ApplicationDbContext();
            try
            {
                if (pizza.Id != 0)
                {
                    db.Entry(pizza).State = EntityState.Modified;
                }
                else
                {
                    db.Pizzas.Add(pizza);
                }
                db.SaveChanges();
            }
            catch (Exception e)
            {

                throw new ApplicationException("error al guardar "+e.Message);
            }
        }
        
        public bool ValPizza(Pizza pizza)
        {
            using ApplicationDbContext db = new ApplicationDbContext();

            var p = db.Pizzas.Where(p => p.Nombre == pizza.Nombre).FirstOrDefault();
            if (p == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Update(Pizza pizza)
        {
            using ApplicationDbContext db = new ApplicationDbContext();

            Pizza oPizza = db.Pizzas.Find(pizza.Id);

            oPizza.Nombre = pizza.Nombre;
            oPizza.Precio = pizza.Precio;

            db.Entry(oPizza).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void GetFavoritePizza() { }
    }
}
