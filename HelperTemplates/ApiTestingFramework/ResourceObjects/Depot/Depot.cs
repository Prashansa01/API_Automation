using ApiAutomationHelper.Support;
using Sainsburys.DepotManagement.Depots.Models;

namespace ApiTestingFramework.ResourceObjects
{
    public class Depot
    {
        // Initialize the URLs and endpoints
        private string authURL = Base.Instance.appSettings["AuthUrl"].ToString();
        private string baseURL = Base.Instance.appSettings["TestApiUrl"].ToString();
        private string resource = Base.Instance.appSettings["ResourceEndPoint"].ToString();
        private string kafka = Base.Instance.appSettings["KafkaEndPoint"].ToString();

        // Get all depots asynchronously
        public async Task GetDepotsAsync()
        {
            await Base.Instance.m_client.GetFlurClientDataAsync(baseURL, baseURL, resource);
        }

        // Get a specific depot asynchronously by ID
        public async Task GetDepotAsync(string id)
        {
            await Base.Instance.m_client.GetFlurClientDataAsync(baseURL, authURL, resource + id);
        }

        // Create a depot asynchronously
        public async Task<HttpResponseMessage> CreateDepot(DepotSubscriptionModel data)
        {
            return await Base.Instance.m_client.FlurlClientPostAsync(data, authURL, baseURL, kafka);
        }

    }
}
