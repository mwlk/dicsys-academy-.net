using Microsoft.AspNetCore.Mvc;
using Services;
using WebApi.Models;
using System;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController: ControllerBase
    {
        private readonly PizzaService _pizzaService;

        public PizzaController(PizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }

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
    }
}