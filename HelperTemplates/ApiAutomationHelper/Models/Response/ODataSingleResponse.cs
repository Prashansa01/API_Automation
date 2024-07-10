using Newtonsoft.Json;

namespace ApiAutomationHelper.Models.Response
{
    public class ODataSingleResponse
    {
        [JsonProperty("@odata.context")]
        public string ODataContext { get; set; }

    }
}
