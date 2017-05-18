using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;

namespace CategorizeTweet
{
    public static class Categorize_Score
    {
        [FunctionName("Categorize_Score")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequestMessage req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            string category = "GREEN";

            // Get request body
            double score = await req.Content.ReadAsAsync<double>();

            // Set category based on score
            if(score < 0.3)
            {
                category = "RED";
            }
            else if (score < 0.6)
            {
                category = "YELLOW";
            }

            return req.CreateResponse(HttpStatusCode.OK, category);
        }
    }
}