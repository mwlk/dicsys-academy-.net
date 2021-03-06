using Microsoft.AspNetCore.Mvc;
using Persistencia.Database.Models;
using Services;
using System;
using WebApi.Models;

namespace WebApi.Controllers
{
    /// <summary>
    /// pedidos controller
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly PedidoService _pedidoService;

        /// <summary>
        /// inject service
        /// </summary>
        /// <param name="pedidoService"></param>
        public PedidoController(PedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        /// <summary>
        /// return all pedidos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get()
        {
            Response oResponse = new Response();

            try
            {
                var list = _pedidoService.GetAll();
                if (list.Count == 0)
                {
                    oResponse.Message = "lista vacia";
                }
                else
                {
                    oResponse.Code = 1;
                    oResponse.Data = list;
                    oResponse.Message = "listado generado con exito";
                }

            }
            catch (Exception ex)
            {

                oResponse.Message = "error " + ex;
            }

            return Ok(oResponse);
        }

        /// <summary>
        /// return pedido by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetById")]
        public IActionResult GetById(int id)
        {
            Response oResponse = new Response();
            try
            {
                var flag = _pedidoService.GetById(id);
                if (flag == null)
                {
                    oResponse.Message = "no se encontro";
                    return NotFound();
                }
                else
                {
                    oResponse.Code = 1;
                    oResponse.Message = "pedido encontrado con exito";
                    oResponse.Data = flag;
                }
            }
            catch (Exception e)
            {

                oResponse.Message = "error al buscar pedido " + e.Message;
            }
            
            return Ok(oResponse);
        }

        /// <summary>
        /// add pedido
        /// </summary>
        /// <remarks> 
        /// insert NombreCliente, DemoraEstimada, (FechaHoraPedido es NOW y Estado por defecto es 1)
        /// </remarks>
        /// <param name="pedido"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] Pedido pedido)
        {
            Response oResponse = new Response();

            try
            {
                _pedidoService.Add(pedido);

                oResponse.Code = 1;
                oResponse.Message = "pedido guardado";
                oResponse.Data = pedido;
            }
            catch (Exception e)
            {
                oResponse.Message = "error al guardar pedido " + e.Message;
            }
            return Ok(oResponse);
        }

        /// <summary>
        /// return variedad favorita
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("VariedadFavorita")]
        public IActionResult Variedad()
        {
            Response oResponse = new Response();

            try
            {
                var resp = _pedidoService.GetPopularVariety();

                oResponse.Code = 1;
                oResponse.Message = "tamanho favorito";
                oResponse.Data = resp;
            }
            catch (Exception e)
            {
                oResponse.Message = "error ocurrido " + e.Message;
            }
            return Ok(oResponse);
        }

        /// <summary>
        /// return tipo favorito
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("TipoFavorito")]
        public IActionResult Tipo()
        {
            Response oResponse = new Response();

            try
            {
                var resp = _pedidoService.GetTipoFavorito();

                oResponse.Code = 1;
                oResponse.Message = "tipo favorito";
                oResponse.Data = resp;
            }
            catch (Exception e)
            {
                oResponse.Message = "ocurrio un error " + e.Message;
            }
            return Ok(oResponse);
        }

        /// <summary>
        /// return pedidos-monto in period
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Pedidos-Montos")]
        public IActionResult GetCantidadMontos(DateTime start, DateTime end)
        {
            Response oResponse = new Response();

            try
            {
                var resp = _pedidoService.GetPedidosInPeriod(start, end);
                if (resp == null)
                {
                    return NotFound();
                }
                oResponse.Code = 1;
                oResponse.Message = "pedidos en periodo";
                oResponse.Data = resp;
            }
            catch (Exception e)
            {
                oResponse.Message = "error ocurrido " + e.Message;
            }

            return Ok(oResponse);
        }
    }
}
