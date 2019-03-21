
using System;
using System.Threading;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace exemplo_api_b.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExampleController : ControllerBase
    {
        public ExampleController()
        {
        }

        [HttpGet]
        public string Get()
        {
            return "Hello";
        }

        [HttpPost]
        public string ApiBCallCommand([FromBody] Request request)
        {
            if (request.WaitMilleseconds.HasValue)
                Thread.Sleep(request.WaitMilleseconds.Value);

            if (!string.IsNullOrEmpty(request.Throws))
                throw new Exception(request.Throws);

            return "Ok!";
        }
    }
}