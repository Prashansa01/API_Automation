using ApiTestingFramework.Support;

namespace ApiTestingFramework.ResourceObjects
{
    public class Depot
    {
        private string resource = Endpoint.Depot;
        private string kafka = Endpoint.Kafka;

        public async Task GetDepotsAsync()
        {
            await TestBase.Instance.m_client.GetFlurClientDataAsync(resource);
        }

        public async Task GetDepotAsync(string id)
        {
            await TestBase.Instance.m_client.GetFlurClientDataAsync(resource + id);
        }

        public async Task<HttpResponseMessage> CreateDepot<T>(T data) 
        {
            return await  TestBase.Instance.m_client.FlurlClientPostAsync(data, kafka);
        }

    }
}
