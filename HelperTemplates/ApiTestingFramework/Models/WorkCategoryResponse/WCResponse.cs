
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTestingFramework.Models.WorkCategoryResponse
{
    internal class WCResponse
    {
        public WCPayload[] WC { get; set; }
    }

    public class WCPayload
    {
        public string Key { get; set; }
        public string LocationId { get; set; }
        public string LocationType { get; set; }
        public string SourceSystem { get; set; }
        public string MessageEventType { get; set; }
        public DateTime MessageEventTimestamp { get; set; }
        public WorkCategoryDetails WorkCategory { get; set; }
    }
}