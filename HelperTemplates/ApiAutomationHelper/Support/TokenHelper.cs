using ApiAutomationHelper.Tests.Interfaces;
using ApiAutomationHelper.Tests.Models;
using Newtonsoft.Json;
using RestSharp;

namespace ApiAutomationHelper.Tests.Helper
{
    public class TokenHelper: ITokenHelper
    {
        private readonly Dictionary<string, string> _appsettings;
        public TokenHelper(Dictionary<string, string> appsettings)
        {
            _appsettings = appsettings;           
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<AuthResponse> GenerateAuthTokenAsync()
        {
             AuthResponse authResponse = new ();
            try
            {
                var authRequest = new AuthRequest
                {
                    ClientId = _appsettings["ClientID"].ToString(),
                    UserName = AzureHelper.GetSecret(_appsettings["KeyVaultName"].ToString(), _appsettings["UserLogOnName"].ToString()),
                    Password = AzureHelper.GetSecret(_appsettings["KeyVaultName"].ToString(), _appsettings["UserPassword"].ToString()),
                    ConnectionType = _appsettings["ConnectionType"].ToString()
                };
                authResponse =  await GetAuthTokenAsync(_appsettings["AuthUrl"].ToString(), authRequest);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return authResponse;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="authRequest"></param>
        /// <returns></returns>
        public async Task<AuthResponse> GetAuthTokenAsync(string url, AuthRequest authRequest)
        {
            var client_ = new RestClient(url);
            string json = JsonConvert.SerializeObject(authRequest);
            RestRequest request = new RestRequest(url, Method.Post);
            request.AddHeader("Content-Type", "application/json; charset=\"UTF-8\"");
            request.AddHeader("clientid", _appsettings["ClientID"].ToString());
            request.RequestFormat = DataFormat.Json;
            request.AddBody(json);
            var response= await client_.ExecutePostAsync(request);
            var responseData = JsonConvert.DeserializeObject<AuthResponse>(response.Content);

            //if (!response.IsSuccessStatusCode)
            //    throw new ApiException
            //    {
            //        StatusCode = (int)response.StatusCode,
            //        Content = await response.Content.ReadAsStringAsync()
            //    };

            return responseData;
        }
 
    }
}
