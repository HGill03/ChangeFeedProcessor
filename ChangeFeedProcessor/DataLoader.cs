using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ChangeFeedProcessor.Infrastructure;
using System.Collections.Generic;
using ChangeFeedProcessor.Models;

namespace ChangeFeedProcessor
{
    public static class DataLoader
    {
       [FunctionName("DataLoader")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            CosmosAdapter adapter = new();

            await adapter.SaveData((new Activity
            {
                Id = DateTime.Now.ToString(),
                DeviceType = "Health",
                Reading = 1
            })).ConfigureAwait(false);

            await adapter.SaveData((new Activity
            {
                Id = DateTime.Now.ToString(),
                DeviceType = "Health",
                Reading = 0
            })).ConfigureAwait(false);

            return new OkObjectResult(true);
        }
    }
}
