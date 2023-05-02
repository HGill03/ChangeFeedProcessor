﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeFeedProcessor.Models
{
    public class Activity
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        public string DeviceType { get; set; }
        public int Reading { get; set; }
    }
}
