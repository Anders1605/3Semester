using AfleveringM404.Models;
using Azure.Identity;
using Microsoft.Azure.Cosmos;
using static System.Net.WebRequestMethods;

namespace AfleveringM404.Services
{
    public class CosmosDBService
    {

        //Endpoint and key from CosmosDB account
        private const string accountEndpoint = "https://ibas-db-account-24729.documents.azure.com:443/";
        private const string accountKey = "rX3SDirzLBvXBLfygXLUoCIXbaLM1St2n79fVbMCKSYkYmZ5rY1NdsNzj6JaMPHRheQyc9G9qfEQACDbYMCveg==";

        private CosmosClient client;
        private Database database;
        private Container container;

        //Constructor for our service. Using the DB name and Partitionkey.  
        public CosmosDBService()
        {
            client = new CosmosClient(accountEndpoint, accountKey);
            database = client.GetDatabase("IBasSupportDB");
            container = database.GetContainer("ibassupport1");
        }

        //Quick test to ensure successful connection. 
        public void TestConnection()
        {
            try
            {
                Console.WriteLine($"Database ID: {database.Id}");
                Console.WriteLine($"Container ID: {container.Id}");
                Console.WriteLine("Connection to Cosmos DB successful!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to connect to Cosmos DB:");
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<SupportMessage> CreateNewSupportMessage(SupportMessage message)
        {
            var response = await container.CreateItemAsync<SupportMessage>(
                message,
                new PartitionKey(message.Category)
                );
            return response.Resource;
        }

        public async Task<List<SupportMessage>> GetAllSupportMessagesAsync()
        {
            var query = "SELECT * FROM c";
            var iterator = container.GetItemQueryIterator<SupportMessage>(query);

            var results = new List<SupportMessage>();
            while (iterator.HasMoreResults)
            {
                var response = await iterator.ReadNextAsync();
                results.AddRange(response.Resource);
            }
            return results;
        }
    }
}
