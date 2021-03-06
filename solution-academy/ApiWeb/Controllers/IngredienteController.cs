using Microsoft.AspNetCore.Mvc;
using Persistencia.Database.Models;
using Services;
using System;
using WebApi.Models;

namespace WebApi.Controllers
{

    /// <summary>
    /// ingrediente controller
    /// </summary>
    [Produces("application/json")] 
    [Route("api/[controller]")]
    [ApiController]
    public class IngredienteController : ControllerBase
    {
        private readonly IngredienteService _ingredienteService;

        /// <summary>
        /// inject service
        /// </summary>
        /// <param name="ingredienteService"></param>
        public IngredienteController(IngredienteService ingredienteService)
        {
            _ingredienteService = ingredienteService;
        }
        
        /// <summary>
        /// return all ingredientes
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// add ingrediente
        /// </summary>
        /// <remarks>
        /// insert Nombre</remarks>
        /// <param name="ingrediente"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] Ingrediente ingrediente)
        {
            Response oResponse = new Response();

            try
            {
                var flag = _ingredienteService.ValIngrediente(ingrediente);
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

        /// <summary>
        /// delete ingrediente by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Response oResponse = new Response();
            try
            {
                var ingrediente = _ingredienteService.Delete(id);
                if (!ingrediente)
                {
                    return NotFound();
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

        /// <summary>
        /// update ingrediente
        /// </summary>
        /// <param name="ingrediente"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Update([FromBody] Ingrediente ingrediente)
        {
            Response oResponse = new Response();

            try
            {
                _ingredienteService.Update(ingrediente);

                oResponse.Code = 1;
                oResponse.Message = "ingrediente actualizado";
                oResponse.Data = ingrediente;
            }
            catch (Exception e)
            {

                oResponse.Message = "error al actualizar "+e.Message;
            }

            return Ok(oResponse);
        }
    }
}
