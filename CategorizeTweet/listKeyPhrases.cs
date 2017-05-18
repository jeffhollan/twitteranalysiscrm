using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using System.Collections;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CategorizeTweet
{
    public static class listKeyPhrases
    {
        [FunctionName("listKeyPhrases")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequestMessage req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");
            // Get request body
            var data = JObject.Parse(await req.Content.ReadAsStringAsync());
            // Get the phrases list
            var phrasesList = ((JArray)data["phrases"]).ToObject<List<string>>();
            // Return comma separated list of phrases
            return req.CreateResponse(HttpStatusCode.OK, string.Join(",", phrasesList));
        }
    }
}