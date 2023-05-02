using ChangeFeedProcessor.Models;
using ChangeFeedProcessor.Services;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChangeFeedProcessor
{
    public static class TextQueueHandler
    {
        [FunctionName("TextQueueHandler")]
        public static async Task RunAsync([CosmosDBTrigger(
            databaseName: "ChangeFeed",
            containerName: "message",
            Connection = "CosmosDBConnectionSetting",
            LeaseContainerName = "leases",
            LeaseContainerPrefix = "text",
            CreateLeaseContainerIfNotExists = true)]IReadOnlyList<Activity> input, ILogger log)
        {
            SmsService messagingService = new();

            await messagingService.SendMessage(Environment.GetEnvironmentVariable("ParticipantPhoneNumber"), "Thank You!").ConfigureAwait(false);

        }
    }
}
