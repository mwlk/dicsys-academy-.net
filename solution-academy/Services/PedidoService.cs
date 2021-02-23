using System;
using System.Collections.Generic;
using System.Linq;
using Persistencia.Database.Models;

namespace Services
{
    public class PedidoService
    {
         
        public string Add() {
            return "funcionando";
        }
        public void Cancel() { }
        public List<Pedido> GetAll()
        {
            using ApplicationDbContext db = new ApplicationDbContext();

                var list = db.Pedidos.ToList();

            return list;
        }
        public void GetPedidoByCliente(string nombre) { }
        public void GetPedidosInPeriod(DateTime inicioPeriod, DateTime finalPeriod) { }
    }
}
