using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading;
using Newtonsoft.Json.Linq;
using System.Text.Json.Nodes;

namespace FunctionApp1
{
    public static class Function1
    {
        //Proxy raw JSON
        [FunctionName("ProxyRawJSON")]
        public static  async IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            //simulate data returned from external api
            var jsonString = "{\"name\":\"jack\", \"age\":10}";

            // return as ContentResult instead of JsonResult because when returning JsonResult
            // the middleware is escaping the jsonString (adding a '\' before every '"')
            var contentResult = new ContentResult();
            contentResult.Content = jsonString;
            contentResult.ContentType = "application/json";
            return contentResult;

        }
    }
}
