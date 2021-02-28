using Microsoft.AspNetCore.Mvc;
using Persistencia.Database.Models;
using Services;
using System;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly PedidoService _pedidoService;

        public PedidoController(PedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

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
