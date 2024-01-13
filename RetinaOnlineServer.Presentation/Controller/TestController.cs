using Microsoft.AspNetCore.Mvc;
using RetinaOnlineServer.Presentation.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetinaOnlineServer.Presentation.Controller
{
    //sealed keywordu bu clasın başka bir clastan inherit edilmesini engeller
    public sealed class TestController : ApiController
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(" işlem başarılı");
        }
    }
}
