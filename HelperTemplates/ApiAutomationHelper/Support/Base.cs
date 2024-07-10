using ApiAutomationHelper.Tests.Helper;
using ApiAutomationHelper.Tests.Interfaces;
using ApiAutomationHelper.Tests.Models;
using Flurl.Http;
using Microsoft.Extensions.Configuration;
using RestSharp;
using System.Reflection;

namespace ApiAutomationHelper.Support
{
    public partial class Base
    {
        private IConfiguration configuration;
        public Dictionary<string, string> appSettings;
        public Dictionary<object, object> testData;
        public HttpResponseMessage Response { get; set; }

        #region Singleton
        private static Base instance;
        private static readonly object lockObject = new object();

        private ITokenHelper _tokenHelper;
        public FlurlClient m_client;

        private Base()
        {
            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                .AddJsonFile("appsettings.json");
            testData = new Dictionary<object, object>();
            configuration = configBuilder.Build();

            appSettings = new Dictionary<string, string>();
            appSettings = DictionaryExtension.GetDictionary(configuration, "AppSettings");
            testData.Add("responseCounter", 0);
            _tokenHelper = new TokenHelper(appSettings);
        }

        /// <summary>
        /// Gets the instance of the Base class using the singleton pattern.
        /// </summary>
        public static Base Instance
        {
            get
            {
                // Double-checked locking for thread safety
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        if (instance == null)
                        {
                            instance = new Base();
                        }
                    }
                }

                return instance;
            }
        }
        #endregion

        /// <summary>
        /// Gets the FlurlClient instance with the specified base URL.
        /// </summary>
        /// <param name="baseURL">The base URL of the API.</param>
        /// <returns>The FlurlClient instance.</returns>
        public FlurlClient GetFlurlClient(string baseURL)
        {
            if (m_client == null)
            {
                Uri apiURL = new Uri(baseURL);//Uri(appSettings["TestApiUrl"]);
                m_client = new FlurlClient(apiURL.AbsoluteUri);
            }
            return m_client;
        }

        /// <summary>
        /// Gets the access token from the specified authentication URL.
        /// </summary>
        /// <param name="authURL">The authentication URL.</param>
        /// <returns>The access token.</returns>
        public async Task<string> GetToken(string authURL)
        {
            AuthResponse authResponse = new AuthResponse();
            var client_ = new RestClient(authURL);
            authResponse = await _tokenHelper.GenerateAuthTokenAsync();
            return authResponse.AccessToken;
        }

        /// <summary>
        /// Clears the instance of the Base class.
        /// </summary>
        public static void ClearInstance()
        {
            lock (lockObject)
            {
                instance = null;
            }
        }
    }
}
