using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Persistencia.Database.Models;

namespace Services
{
    public class PedidoService
    {
         
        public void Add(Pedido pedido) {
            using ApplicationDbContext db = new ApplicationDbContext();

            try
            {
                if (pedido.Id != 0 )
                {
                    db.Entry(pedido).State = EntityState.Modified;
                }
                else
                {
                    Pedido oPedido = new Pedido()
                    {
                        NombreCliente = pedido.NombreCliente,
                        FechaHoraPedido = DateTime.Now,
                        DemoraEstimada = pedido.DemoraEstimada,
                        Estado = 1
                    };

                    db.Pedidos.Add(oPedido);
                }

                db.SaveChanges();
            }
            catch (Exception e)
            {

                throw new ApplicationException("error al guardar pedido "+e.Message);
            }
        }

        public void Cancel() { }

        public List<Pedido> GetAll()
        {
            using ApplicationDbContext db = new ApplicationDbContext();

                var list = db.Pedidos.ToList();

            return list;
        }

        public Pedido GetById(int id)
        {
            using ApplicationDbContext db = new ApplicationDbContext();

            var pedido = db.Pedidos.Find(id);

            if (pedido == null)
            {
                return null;
            }

            return pedido;
        }

        public string GetPopularVariety()
        {
            /* var query = (from dp in db.DetallePedidos
                         orderby dp.Tamanho
                         group dp by dp.Tamanho into grp
                         select new { key = grp.Key, cont = grp.Count() });

            */

            string resp = "";
            
            using ApplicationDbContext db = new ApplicationDbContext();

            var media = (from dp in db.DetallePedidos
                         where dp.Tamanho == 4
                         select dp.Tamanho)
                        .Count();

            var normal = (from dp in db.DetallePedidos
                         where dp.Tamanho == 8
                         select dp.Tamanho)
                       .Count();

            var large = (from dp in db.DetallePedidos
                         where dp.Tamanho == 12
                         select dp.Tamanho)
                       .Count();

            var metro = (from dp in db.DetallePedidos
                         where dp.Tamanho == 20
                         select dp.Tamanho)
                       .Count();

            if (media > normal && media > large && media > metro)
            {
                resp = "la pizza favorita es la media pizza";
            } 
            if (normal > media && normal > large && normal > metro)
            {
                resp = "la pizza favorita es la normal de 8 porciones";
            }
            if (large > media && large > normal && large > metro)
            {
                resp = "la pizza favorita es la large de 12 porciones";
            }
            if (metro > media && metro > normal && metro > large)
            {
                resp = "la pizza favorita es la metro de 20 porciones";
            }



            return resp;
        }

        public void GetPedidoByCliente(string nombre) { }
        public void GetPedidosInPeriod(DateTime inicioPeriod, DateTime finalPeriod) { }
    }
}
