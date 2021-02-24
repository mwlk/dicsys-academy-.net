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
    public class IngredienteController : ControllerBase
    {
        private readonly IngredienteService _ingredienteService;

        public IngredienteController(IngredienteService ingredienteService)
        {
            _ingredienteService = ingredienteService;
        }
        // GET: api/<IngredienteController>
        [HttpGet]
        public IActionResult Get()
        {
            Response oResponse = new Response();
            try
            {
                var list = _ingredienteService.GetAll();
                if (list.Count == 0)
                {
                    oResponse.Message = "lista vacia";
                    
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
                oResponse.Message = "error al generar la lista " + e.Message;
            }
            return Ok(oResponse);
        }

        // GET api/<IngredienteController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<IngredienteController>
        [HttpPost]
        public IActionResult Post([FromBody] Ingrediente ingrediente)
        {
            Response oResponse = new Response();

            try
            {
                var flag = _ingredienteService.GetIngrediente(ingrediente);
                if (flag == true)
                {
                    _ingredienteService.Add(ingrediente);

                    oResponse.Code = 1;
                    oResponse.Data = ingrediente;
                    oResponse.Message = "ingrediente registrado con exito";
                }
                else
                {
                    oResponse.Code = 0;
                    oResponse.Message = "ingrediente ya existente";
                }
            }
            catch (Exception e)
            {

                oResponse.Message = "error al registrar "+e.Message;
            }
            return Ok(oResponse);
        }

        // DELETE api/<IngredienteController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Response oResponse = new Response();
            try
            {
                var ingrediente = _ingredienteService.Delete(id);
                if (!ingrediente)
                {
                    return BadRequest();
                }
                oResponse.Code = 1;
                oResponse.Data = ingrediente;
                oResponse.Message = "ingrediente eliminado";
            }
            catch (Exception e)
            {
                oResponse.Message = "Error al eliminar " + e.Message;
            }
            

            
            return Ok(oResponse);
        }
    }
}
