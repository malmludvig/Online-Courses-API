using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using API.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/")]
    public class TeapotController : ControllerBase
    {
        [HttpGet("teapot")]
        public StatusCodeResult GetTeapot(){
            return StatusCode(418);
        }
    }
}
