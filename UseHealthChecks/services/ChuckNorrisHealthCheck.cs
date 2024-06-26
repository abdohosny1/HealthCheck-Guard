using Microsoft.Extensions.Diagnostics.HealthChecks;
using RestSharp;

namespace MyUseHealthChecks.services
{
    public class ChuckNorrisHealthCheck : IHealthCheck
    {
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            var url = "https://matchilling-chuck-norris-jokes-v1.p.rapidapi.com/jokes/random";

            var client = new RestClient();
            var request = new RestRequest(url,Method.Get);
            request.AddHeader("x-rapidapi-key", "ac83b0fefcmsh4b87e02f273ac48p1052d9jsn57ec4c976b31");
            request.AddHeader("x-rapidapi-host", "matchilling-chuck-norris-jokes-v1.p.rapidapi.com");
            request.AddHeader("accept", "application/json");

            var response = await client.ExecuteAsync(request);

            if (response.IsSuccessful)
                return HealthCheckResult.Healthy();
            else
                return HealthCheckResult.Unhealthy();


        }
    }
}
