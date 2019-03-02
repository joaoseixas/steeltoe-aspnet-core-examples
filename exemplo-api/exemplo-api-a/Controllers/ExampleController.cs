using System.Net.Http;
using exemplo_api_a.HystrixCommands;
using Microsoft.AspNetCore.Mvc;
using Steeltoe.Common.Discovery;

namespace exemplo_api_a.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExampleController : ControllerBase
    {
        private readonly ApiBCallCommand _apiBCall;

        public ExampleController(ApiBCallCommand apiBCall)
        {
            this._apiBCall = apiBCall;
        }

        [HttpPost]
        public string ApiBCallCommand(Request request)
        {
            _apiBCall.Input(request);

            return _apiBCall.Execute();
        }
    }
}