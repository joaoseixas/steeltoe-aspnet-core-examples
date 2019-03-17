using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Steeltoe.Common.HealthChecks;

namespace exemplo_api_a.HealthContributors
{
    public class ApiBCheck : IHealthContributor
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public string Id => "ApiBCheck";
        public static HealthStatus Status { get; set; } = HealthStatus.UP;
        public ApiBCheck(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public HealthCheckResult Health()
        {
            var result = new HealthCheckResult()
            {
                Status = HealthStatus.UP,
                Description = "API B OK!"
            };

            try
            {
                //HttpClient client = _httpClientFactory.CreateClient("api-b");
                HttpClient client = _httpClientFactory.CreateClient("zuul-server");
                HttpRequestMessage request = new HttpRequestMessage();
                var response = client.GetStringAsync("health").Result;

                dynamic health = JObject.Parse(response);

                if (health.status != HealthStatus.UP.ToString())
                {
                    result = new HealthCheckResult()
                    {
                        Status = HealthStatus.WARNING,
                        Description = $"API B: {health.status}"
                    };
                }


            }
            catch (Exception ex)
            {
                result = new HealthCheckResult()
                {
                    Status = HealthStatus.WARNING,
                    Description = "Falha ao verificar API B"
                };
                result.Details.Add("fail", ex.Message);
            }

            result.Details.Add("status", result.Status.ToString());
            result.Details.Add("details", result.Description);
            return result;
        }
    }
}