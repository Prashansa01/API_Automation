using Flurl;
using Flurl.Http;

namespace ApiAutomationHelper.Support
{
    public static class ApiClientExtension
    {
        /// <summary>
        /// Method to asynchronously get data from the Flurl client.
        /// </summary>
        /// <param name="client">The Flurl client.</param>
        /// <param name="baseURL">The base URL.</param>
        /// <param name="authURL">The authentication URL.</param>
        /// <param name="endpoint">The endpoint.</param>
        /// <returns>The response content as a string.</returns>
        public static async Task<string> GetFlurClientDataAsync(this FlurlClient client, string baseURL, string authURL, string endpoint)
        {
            var m_client = Base.Instance.GetFlurlClient(baseURL);
            var token = await Base.Instance.GetToken(authURL);

            // Send a GET request to the specified endpoint with the Flurl client
            HttpResponseMessage response = await StringExtensions.AppendPathSegments("", endpoint)
                .WithClient(m_client).WithOAuthBearerToken(token)
                .GetAsync();

            Base.Instance.testData.AddResponseJson(response);
            return response.Content.ReadAsStringAsync().Result;
        }

        /// <summary>
        /// Method to asynchronously post data to the Flurl client.
        /// </summary>
        /// <typeparam name="T">The type of the data to be posted.</typeparam>
        /// <param name="client">The Flurl client.</param>
        /// <param name="data">The data to be posted.</param>
        /// <param name="baseURL">The base URL.</param>
        /// <param name="authURL">The authentication URL.</param>
        /// <param name="endpoint">The endpoint.</param>
        /// <returns>The HTTP response message.</returns>
        public static async Task<HttpResponseMessage> FlurlClientPostAsync<T>(this FlurlClient client, T data, string baseURL, string authURL, string endpoint)
        {
            var m_client = Base.Instance.GetFlurlClient(baseURL);
            var token = Base.Instance.GetToken(authURL);

            string searchUrl = m_client.BaseUrl;
            var url = searchUrl
                .AppendPathSegment(endpoint)
                .WithOAuthBearerToken(token.ToString());

            // Send a POST request to the specified endpoint with the Flurl client
            HttpResponseMessage result = await url.PostJsonAsync(data);
            return result;
        }
    }
}
