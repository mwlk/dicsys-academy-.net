using Microsoft.AspNetCore.Mvc;
using Services;
using WebApi.Models;
using System;
using Persistencia.Database.Models;

namespace WebApi.Controllers
{
    /// <summary>
    /// controller pizza
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController: ControllerBase
    {
        private readonly PizzaService _pizzaService;

        /// <summary>
        /// inject service
        /// </summary>
        /// <param name="pizzaService"></param>
        public PizzaController(PizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }

        /// <summary>
        /// return all pizzas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            Response oResponse = new Response();
            try
            {
                var list = _pizzaService.GetAll();
                if (list.Count == 0)
                {
                    oResponse.Message = "lista vacia";
                }
                else
                {
                    oResponse.Code = 1;
                    oResponse.Message = "listado generado con exito";
                    oResponse.Data = list;
                }
            }
            catch (Exception ex)
            {

                oResponse.Message = "error " + ex.Message;
            }

            return Ok(oResponse);
        }

        /// <summary>
        /// add pizza
        /// </summary>
        /// <remarks>
        /// insert Nombre y Precio
        /// </remarks>
        /// <param name="pizza"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody]Pizza pizza)
        {
            Response oResponse = new Response();
            try
            {
                var flag = _pizzaService.ValPizza(pizza);
                if (flag == true)
                {
                    _pizzaService.Create(pizza);

                    oResponse.Code = 1;
                    oResponse.Message = "pizza registrada";
                    oResponse.Data = pizza;
                }
                else
                {
                    oResponse.Code = 0;
                    oResponse.Message = "pizza ya registrada";
                }
            }
            catch (Exception e)
            {
                oResponse.Message = "error al guardar pizza" + e.Message; 
            }
            return Ok(oResponse);
        }

        /// <summary>
        /// edit pizza
        /// </summary>
        /// <param name="pizza"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Edit(Pizza pizza)
        {
            Response oResponse = new Response();

            try
            {
                _pizzaService.Update(pizza);

                oResponse.Code = 1;
                oResponse.Message = "pizza actualizada";
                oResponse.Data = pizza;
            }
            catch (Exception e)
            {

                oResponse.Message = "error al actualizar" + e.Message;
            }

            return Ok(oResponse);
        }
    }
}