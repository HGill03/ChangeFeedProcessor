using ChangeFeedProcessor.Models;
using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeFeedProcessor.Infrastructure
{
    public class CosmosAdapter
    {
        public CosmosClient Client { get; }
        
        public CosmosAdapter()
        {
            Client = new CosmosClient(
                Environment.GetEnvironmentVariable("CosmosDBConnectionSetting"));

        }
        public async Task SaveData(Message data) 
        {
            await Client.GetContainer(Environment.GetEnvironmentVariable("DataBaseId"), Environment.GetEnvironmentVariable("ContainerIdMessage")).CreateItemAsync(data);
        }
        public async Task SaveData(Activity data)
        {
            var temp = Environment.GetEnvironmentVariable("DataBaseId");
            Database database = await Client.CreateDatabaseIfNotExistsAsync(id: "ChangeFeed");
            Container container = await database.CreateContainerIfNotExistsAsync(
                id: "activity",
                partitionKeyPath: "/id",
                throughput: 400
            );

            var response = await container.CreateItemAsync<Activity>(item: data, partitionKey: new PartitionKey(data.Id)).ConfigureAwait(false);
        }
    }
}
