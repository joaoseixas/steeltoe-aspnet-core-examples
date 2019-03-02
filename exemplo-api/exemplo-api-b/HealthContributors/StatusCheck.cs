using Steeltoe.Common.HealthChecks;

namespace exemplo_api_b.HealthContributors
{
    public class StatusCheck : IHealthContributor
    {
        public string Id => "StatusCheck";
        public static HealthStatus Status { get; set; } = HealthStatus.UP;

        public HealthCheckResult Health()
        {
            var result = new HealthCheckResult
            {
                // this is used as part of the aggregate, it is not directly part of the middleware response
                Status = Status,
                Description = "This health check does not check anything"
            };
            result.Details.Add("status", Status.ToString());
            return result;
        }
    }
}