using Microsoft.EntityFrameworkCore;
using Persistencia.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class FacturaService
    {
        public void Create(Factura factura) {
            using ApplicationDbContext db = new ApplicationDbContext();

            try
            {
                if (factura.Id != 0)
                {
                    db.Entry(factura).State = EntityState.Modified;
                }
                else
                {
                    db.Facturas.Add(factura);
                }
                db.SaveChanges();
            }
            catch (Exception e)
            {

                throw new ApplicationException("Error al registrar " + e.Message);
            }
        }

        public List<Factura> GetAll()
        {
            using ApplicationDbContext db = new ApplicationDbContext();

            var list = db.Facturas.ToList();

            return list;
        }

        public Factura GetById(int id)
        {
            using ApplicationDbContext db = new ApplicationDbContext();

            var factura = db.Facturas.Find(id);
            if (factura == null)
            {
                return null;
            }
            return factura;
        }

        public void GetByPedido(int id) { }
        public void GetIngresosInPeriod(DateTime inicioPeriod, DateTime finalPeriod) { }
        public void GetByFormaPago(int id) { }
    }
}
