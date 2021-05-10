using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DockerController : ControllerBase
    {
        // GET: api/<DockerController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("i am a docker containter");
        }

       
    }
}
