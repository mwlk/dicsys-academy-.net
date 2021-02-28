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

            try
            {
                var normal = (from dp in db.DetallePedidos
                              where dp.Tamanho == 8
                              select dp.Tamanho)
                      .Count();

                var large = (from dp in db.DetallePedidos
                             where dp.Tamanho == 10
                             select dp.Tamanho)
                           .Count();

                var extra = (from dp in db.DetallePedidos
                             where dp.Tamanho == 12
                             select dp.Tamanho)
                           .Count();

                if (normal > large && normal > extra)
                    resp = "la pizza favorita es la de 8 porciones";

                if (large > normal && large > extra)
                    resp = "la pizza favorita es la de 10 porciones";

                if (extra > normal && extra > large)
                    resp = "la pizza favorita es la de 12 porciones";
            }
            catch (Exception e)
            {

                throw new ApplicationException("ocurrio un error " + e.Message);
            }


            return resp;
        }

        public string GetTipoFavorito()
        {
            string resp = "";

            using ApplicationDbContext db = new ApplicationDbContext();
            try
            {
                var piedra = (from dp in db.DetallePedidos
                                 where dp.Tipo == 1
                                 select dp.Tipo).Count();

                var parrilla = (from dp in db.DetallePedidos
                                 where dp.Tipo == 2
                                 select dp.Tipo).Count();

                var molde = (from dp in db.DetallePedidos
                                 where dp.Tipo == 3
                                 select dp.Tipo).Count();

                if (piedra > parrilla && piedra > molde)
                    resp = "la pizza favorita es a la piedra";

                if (parrilla > piedra && parrilla > molde)
                    resp = "la pizza favorita es a la parrilla";

                if (molde > piedra && molde > parrilla)
                    resp = "la pizza favorita es al molde";
            }
            catch (Exception e)
            {
                throw new ApplicationException("ocurrio un error " + e.Message);
            }
            return resp;
        }

        public string GetPedidosInPeriod(DateTime start, DateTime end)
        {
            string resp = "";

            using ApplicationDbContext db = new ApplicationDbContext();

            try
            {
                var cantidad = (from p in db.Pedidos
                                where p.FechaHoraPedido > start && p.FechaHoraPedido < end
                                select p).Count();

                var monto = (from p in db.Pedidos
                             join dp in db.DetallePedidos on p.Id equals dp.PedidoId
                             where p.FechaHoraPedido > start && p.FechaHoraPedido < end
                             select dp.Subtotal).Sum();

                resp = "la cantidad de pedidos es: " + cantidad + " lo recaudado es: " + monto;
            }
            catch (Exception e)
            {

                throw new ApplicationException("error ocurrido " + e.Message);
            }
            return resp;
        }
    }
}
