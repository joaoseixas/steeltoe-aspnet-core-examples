using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using exemplo_api_a.Controllers;
using Microsoft.Extensions.Logging;
using Steeltoe.CircuitBreaker.Hystrix;

namespace exemplo_api_a.HystrixCommands
{
    public class ApiBCallCommand : HystrixCommand<string>
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private Request _request;

        public ApiBCallCommand(IHystrixCommandOptions options, IHttpClientFactory httpClientFactory)
            : base(options)
        {
            this._httpClientFactory = httpClientFactory;
        }

        public void Input(Request request)
        {
            _request = request;
        }

        protected override async Task<string> RunAsync()
        {
            var httpClient = _httpClientFactory.CreateClient("zuul-server");
            var res = await httpClient.PostAsync<Request>("api/Example", _request ?? new Request(), new JsonMediaTypeFormatter());
            var content = await res.Content.ReadAsStringAsync();

            if (res.StatusCode == HttpStatusCode.InternalServerError)
                throw new Exception(content);

            if (res.StatusCode != HttpStatusCode.OK)
                return $"{res.StatusCode} - {content}";

            return await res.Content.ReadAsStringAsync();
        }

        protected override string RunFallback()
        {
            return "Circuito Aberto";
        }
    }
}