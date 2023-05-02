using ChangeFeedProcessor.Models;
using ChangeFeedProcessor.Services;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChangeFeedProcessor
{
    /// <summary>
    /// Cosmos DB trigger for Change Feed event listening.
    /// Note - This is not used. Currently we reply directly from MessageReceiver function.
    /// However, this can be used by adding a record to DB from MessageReceiver function in collection Message.
    /// This Trigger will be triggered when a record is added to Message Collection. 
    /// </summary>
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
