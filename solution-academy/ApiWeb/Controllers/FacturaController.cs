using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services;
using WebApi.Controllers;
using Persistencia.Database.Models;
using WebApi.Models;

namespace WebApi.Controllers
{
    /// <summary>
    /// factura controller
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private readonly FacturaService _facturaService;
        
        /// <summary>
        /// inject service
        /// </summary>
        /// <param name="facturaService"></param>
        public FacturaController(FacturaService facturaService)
        {
            _facturaService = facturaService;
        }

        /// <summary>
        /// return all facturas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            Response oResponse = new Response();
            try
            {
                var list = _facturaService.GetAll();

                if (list.Count == 0)
                {
                    oResponse.Code = 0;
                    oResponse.Message = "listado vacio";
                }
                else
                {
                    oResponse.Code = 1;
                    oResponse.Message = "listado generado";
                    oResponse.Data = list;
                }
            }
            catch (Exception e)
            {
                oResponse.Message = "error al generar listado de facturas " + e.Message;
            }
            return Ok(oResponse);
        }

        /// <summary>
        /// return factura by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Response oResponse = new Response();

            try
            {
                var factura = _facturaService.GetById(id);

                if (factura == null)
                {
                    oResponse.Message = "no se encontro la factura";
                    return NotFound();
                }
                oResponse.Code = 1;
                oResponse.Message = "factura encontrada";
                oResponse.Data = factura;
            }
            catch (Exception e)
            {
                oResponse.Message = "error al buscar " + e.Message;
            }
            return Ok(oResponse);
        }

        /// <summary>
        /// add factura
        /// </summary>
        /// <remarks>
        /// insert FormaPago, PedidoId
        /// </remarks>
        /// <param name="factura"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] Factura factura)
        {
            Response oResponse = new Response();

            try
            {
                _facturaService.Create(factura);

                oResponse.Code = 1;
                oResponse.Message = "factura guardada con exito";
                oResponse.Data = factura;
            }
            catch (Exception e)
            {

                oResponse.Message = "error al guardar factura " + e.Message;
            }
            return Ok(oResponse);
        }

        /// <summary>
        /// method return ingresos
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetIngresos")]
        public IActionResult GetIngresos(DateTime start, DateTime end)
        {
            Response oResponse = new Response();

            try
            {
                var resp = _facturaService.GetIngresosInPeriod(start, end);
                if (resp == null)
                {
                    return NotFound();
                }
                oResponse.Code = 1;
                oResponse.Message = "resultado encontrado";
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
