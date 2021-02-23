using Microsoft.AspNetCore.Mvc;
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

        /*[HttpGet]
        [Route("test")]
        public IActionResult Get2(string s)
        {
            Response oResponse = new Response
            {
                Code = 1,
                Data = pedidoService.Add() + s,
                Message = "si funciona"
            };
            return Ok(oResponse);
        }*/
    }
}
