using Microsoft.EntityFrameworkCore;
using Persistencia.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class IngredienteService
    {
        public void Add(Ingrediente ingrediente) {
            using ApplicationDbContext db = new ApplicationDbContext();
            try
            {
                if (ingrediente.Id != 0)
                {
                    db.Entry(ingrediente).State = EntityState.Modified;
                }
                else
                {
                   db.Ingredientes.Add(ingrediente);
                }
                db.SaveChanges();
                
            }
            catch (Exception e)
            {

                throw new ApplicationException("Error al guardar " + e.Message);
            }
        }
        public bool Delete(int id) {
            using ApplicationDbContext db = new ApplicationDbContext();

            var busqueda = db.Ingredientes.Find(id);

            if(busqueda != null)
            {
                db.Ingredientes.Remove(busqueda);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<Ingrediente> GetAll() {
            using ApplicationDbContext db = new ApplicationDbContext();

            var list = db.Ingredientes.ToList();

            return list;
        }
        public void GetByPizza(int id) { }

        public bool GetIngrediente(Ingrediente ingrediente)
        {
            ApplicationDbContext db = new ApplicationDbContext();

            var ing = db.Ingredientes.Where(i => i.Nombre == ingrediente.Nombre).FirstOrDefault();
            if (ing == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
