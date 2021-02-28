using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persistencia.Database.Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetallePedidoController : ControllerBase
    {
        private readonly DetallePedidoService _detallePedidoService;

        public DetallePedidoController(DetallePedidoService detallePedidoService)
        {
            _detallePedidoService = detallePedidoService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            Response oResponse = new Response();
            var list = _detallePedidoService.Get();
            try
            {
                if (list == null)
                {
                    return NotFound();
                }
                oResponse.Code = 1;
                oResponse.Message = "listado de detalles generados";
                oResponse.Data = list;
            }
            catch (Exception e)
            {
                oResponse.Message = "error ocurrido" + e.Message;
            }
            return Ok(oResponse);
        }

        [HttpPost]
        public IActionResult Post([FromBody]DetallePedido detalle)
        {
            Response oResponse = new Response();

            try
            {
                _detallePedidoService.Create(detalle);

                oResponse.Code = 1;
                oResponse.Message = "detalle agregado";
                oResponse.Data = detalle;
            }
            catch (Exception e)
            {
                oResponse.Message = ("ocurrio un error " + e.Message);
            }
            return Ok(oResponse);
        }
    }
}
