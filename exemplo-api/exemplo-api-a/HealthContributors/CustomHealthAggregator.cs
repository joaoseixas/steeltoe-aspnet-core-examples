using System.Collections.Generic;
using System.Linq;
using Steeltoe.Common.HealthChecks;
using Steeltoe.Management.Endpoint.Health;

namespace exemplo_api_a.HealthContributors
{
    public class CustomHealthAggregator : IHealthAggregator
    {
        public HealthCheckResult Aggregate(IList<IHealthContributor> contributors)
        {
            if (contributors == null)
            {
                return new HealthCheckResult();
            }

            var result = new HealthCheckResult();
            foreach (var contributor in contributors)
            {
                HealthCheckResult h = null;
                try
                {
                    h = contributor.Health();
                }
                catch
                {
                    h = new HealthCheckResult();
                }

                if (h.Status > result.Status)
                {
                    result.Status = h.Status;
                }

                if (!result.Details.ContainsKey(contributor.Id))
                {
                    result.Details.Add(contributor.Id, h.Details);
                }
                else
                {
                    // add the contribtor with a -n appended to the id
                    result.Details.Add(string.Concat(contributor.Id, "-", result.Details.Count(k => k.Key == contributor.Id)), h.Details);
                }
            }

            return result;
        }


    }
}