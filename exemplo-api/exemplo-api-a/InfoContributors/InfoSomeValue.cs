using Steeltoe.Management.Endpoint.Info;

namespace exemplo_api_a.InfoContributors
{
    public class InfoSomeValue : IInfoContributor
    {
        public void Contribute(IInfoBuilder builder)
        {
            // pass in the info
            builder.WithInfo("arbitraryInfo", new { someProperty = "someValue" });
        }
    }
}