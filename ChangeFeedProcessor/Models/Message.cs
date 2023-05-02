using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeFeedProcessor.Models
{
    public class Message
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("from")]
        public string From { get; set; }
        [JsonProperty("to")]
        public string To { get; set; }
        [JsonProperty("message")]
        public string Text { get; set; }
    }
}
