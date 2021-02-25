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
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private readonly FacturaService _facturaService;

        public FacturaController(FacturaService facturaService)
        {
            _facturaService = facturaService;
        }
        // GET: api/<FacturaController>
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

        // GET api/<FacturaController>/5
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

        // POST api/<FacturaController>
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

        /* PUT api/<FacturaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
        */

        
    }
}
