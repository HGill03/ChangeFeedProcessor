using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.EventGrid;
using Microsoft.Extensions.Logging;
using Azure.Messaging.EventGrid;
using System;
using ChangeFeedProcessor.Infrastructure;
using ChangeFeedProcessor.Models;
using Newtonsoft.Json;
using System.Threading.Tasks;
using ChangeFeedProcessor.Services;

namespace ChangeFeedProcessor
{
    /// <summary>
    /// Event Trigger which gets triggers when a message is received from the Communication Services event queue. 
    /// This is where we can add 2 way SMS logic.
    /// </summary>
    public static class MessageReceiver
    {
        [FunctionName("MessageReceiver")]
        public static async Task RunAsync([EventGridTrigger]EventGridEvent eventGridEvent, ILogger log)
        {
            SmsService messagingService = new();
            await messagingService.SendMessage(Environment.GetEnvironmentVariable("ParticipantPhoneNumber"), "Thank You").ConfigureAwait(false);

        }
    }
}
