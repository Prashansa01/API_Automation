using Azure.Core;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

namespace ApiAutomationHelper.Tests.Helper
{
    public static class AzureHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyVaultName"></param>
        /// <param name="secretKey"></param>
        /// <returns> string connection value</returns>
        public static string GetSecret(string keyVaultName, string secretKey)
        {
            try
            {
                var secretClient = SetupSecretClient(keyVaultName);

                if (secretClient != null)
                {
                    if (!string.IsNullOrWhiteSpace(secretKey))
                        return secretClient.GetSecret(secretKey)?.Value?.Value;
                    else
                        throw new Exception("Secret Key is Null or empty");
                }
                else
                    throw new Exception("Secret Client is Null or empty");

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyVaultName"></param>
        /// <returns> SecretClient </returns>
        /// <exception cref="Exception"></exception>
        private static SecretClient SetupSecretClient(string keyVaultName)
        {
            try
            {
                if (!string.IsNullOrEmpty(keyVaultName))
                {
                    SecretClientOptions secretClientOptions = new()
                    {
                        Retry = {
                        Delay = TimeSpan.FromSeconds(2),
                        MaxDelay = TimeSpan.FromSeconds(10),
                        MaxRetries = 3,
                        Mode = RetryMode.Exponential
                    }
                    };

                    var tenantId = Environment.GetEnvironmentVariable("TENANT_ID");
                    var clientId = Environment.GetEnvironmentVariable("AZ_CLIENT_ID");
                    var clientSecret = Environment.GetEnvironmentVariable("AZ_CLIENT_SECRET");

                    if (!string.IsNullOrEmpty(tenantId) && !string.IsNullOrEmpty(clientId) && !string.IsNullOrEmpty(clientSecret))
                        return new SecretClient(new Uri($"https://{keyVaultName}.vault.azure.net"),
                            new ClientSecretCredential(tenantId, clientId, clientSecret),
                        secretClientOptions);

                    return new SecretClient(new Uri($"https://{keyVaultName}.vault.azure.net"), new DefaultAzureCredential(), secretClientOptions);
                }
                else
                {
                    throw new Exception("Key Vault Name is empty or null");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public static async Task SetSecretAsync(string keyVaultName, string key, string value, short expiryMinutes)
        {
            var secretClient = SetupSecretClient(keyVaultName);
            try
            {

                if (secretClient != null)
                {
                    if (!string.IsNullOrWhiteSpace(key))
                    {
                        var keyVaultSecret = new KeyVaultSecret(key, value);
                        keyVaultSecret.Properties.ExpiresOn = DateTimeOffset.UtcNow.AddMinutes(expiryMinutes);

                        var response = await secretClient.SetSecretAsync(keyVaultSecret);

                        if (response?.GetRawResponse().Status != 200)
                            throw new Exception($"Error while setting secret for key {key}.");
                    }
                    else
                        throw new Exception("Secret Key is Null or empty");
                }
                else
                    throw new Exception("Secret Client is Null or empty");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        
    }
}
