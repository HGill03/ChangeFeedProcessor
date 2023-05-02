using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ChangeFeedProcessor.Models;
using ChangeFeedProcessor.Services;
using Microsoft.Azure.Documents;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace ChangeFeedProcessor
{
    public class QueueHandler
    {

       [FunctionName("QueueHandler")]
        public static async Task RunAsync([CosmosDBTrigger(
            databaseName: "ChangeFeed",
            containerName: "activity",
            Connection = "CosmosDBConnectionSetting",
            LeaseContainerName = "leases",
            LeaseContainerPrefix = "dev",
            CreateLeaseContainerIfNotExists = true)]IReadOnlyList<Activity> input, ILogger log)
        {
            SmsService messagingService = new();
            foreach (Activity data in input) {
                if (data.Reading <= 0)
                    await messagingService.SendMessage(Environment.GetEnvironmentVariable("ParticipantPhoneNumber"), "Are you wearing your watch?").ConfigureAwait(false);
            }
        }
    }
}
