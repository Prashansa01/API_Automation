using Newtonsoft.Json;

namespace ApiAutomationHelper.Support
{
    static class SerializerHelper
    {
        public static string? PreparePayload(this object model)
        {
            if (model != null)
            {
                return JsonConvert.SerializeObject(model, Formatting.None,
                            new JsonSerializerSettings
                            {
                                NullValueHandling = NullValueHandling.Ignore
                            });
            }
            else
            {
                return null;
            }
            
        }
    }
}
