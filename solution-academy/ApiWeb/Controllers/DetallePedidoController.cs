using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            oResponse.Message = "funcionando";
            return Ok(oResponse);
        }
    }
}
