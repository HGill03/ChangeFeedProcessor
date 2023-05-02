using Azure.Communication.Sms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeFeedProcessor.Services
{
    /// <summary>
    /// SMS service with uses Azure Communication Services to send SMS. Expects Comm. Service instance in Azure.
    /// </summary>
    public class SmsService
    {
        private readonly SmsClient smsClient;
        public SmsService() => smsClient = new SmsClient(Environment.GetEnvironmentVariable("CommConnectionString"));

        public async Task SendMessage(string phoneNumber, string message)
        {
            if (phoneNumber != null && phoneNumber.Length > 0)
            {
                await smsClient.SendAsync(
                from: Environment.GetEnvironmentVariable("TeamPhoneNumber"),
                to: phoneNumber,
                message: message, new SmsSendOptions(true)
                {
                    Tag = "demo"
                }).ConfigureAwait(false);
            }
        }
    }
}
