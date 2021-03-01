using Microsoft.EntityFrameworkCore;
using Persistencia.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class DetallePedidoService
    {
        public void Create(DetallePedido detalle)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            
            try
            {
                if (detalle.Id != 0)
                {
                    db.Entry(detalle).State = EntityState.Modified;
                }
                else
                {
                    var precio = db.Pizzas.Find(detalle.PizzaId).Precio;
                    double mtipo = 0;
                    switch (detalle.Tipo)
                    {
                        case 1:
                            mtipo = 1;
                            break;
                        case 2:
                            mtipo = 1.2;
                            break;
                        case 3:
                            mtipo = 1.3;
                            break;
                    }

                    double mtamanho = 0;
                    switch (detalle.Tamanho)
                    {
                        case 8:
                            mtamanho = 1;
                            break;
                        case 10:
                            mtamanho = 1.1;
                            break;
                        case 12:
                            mtamanho = 1.2;
                                break;
                    }

                    DetallePedido oDetalle = new DetallePedido
                    {
                        PedidoId = detalle.PedidoId,
                        PizzaId = detalle.PizzaId,
                        Cantidad = detalle.Cantidad,
                        Subtotal = (float)(precio * detalle.Cantidad * mtipo * mtamanho),
                        Tipo = detalle.Tipo,
                        Tamanho = detalle.Tamanho
                    };
                    db.DetallePedidos.Add(oDetalle);
                }
                db.SaveChanges();
            }
            catch (Exception e)
            {

                throw new ApplicationException("error ocurrido" + e.Message);
            }
        }
        public List<DetallePedido> Get() {
            using ApplicationDbContext db = new ApplicationDbContext();

            var list = db.DetallePedidos.ToList();

            return list;

        }
        public void GetById(int id) { }
    }
}
