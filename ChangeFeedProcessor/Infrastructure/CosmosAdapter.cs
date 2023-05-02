using ChangeFeedProcessor.Models;
using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeFeedProcessor.Infrastructure
{
    /// <summary>
    /// Adapter to perform basic Azure Cosmos DB Functions. Expects Database and COntiners to be already present.
    /// </summary>
    public class CosmosAdapter
    {
        public CosmosClient Client { get; }

        public CosmosAdapter() => Client = new CosmosClient(
                Environment.GetEnvironmentVariable("CosmosDBConnectionSetting"));

        public async Task SaveData(Message data) => await Client.GetContainer(Environment.GetEnvironmentVariable("DataBaseId"), Environment.GetEnvironmentVariable("ContainerIdMessage")).CreateItemAsync(data);

        public async Task SaveData(Activity data) => await Client.GetContainer(Environment.GetEnvironmentVariable("DataBaseId"), Environment.GetEnvironmentVariable("ContainerIdActivity")).CreateItemAsync(data);
    }
}
