using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTestingFramework.Models.WorkCategoryResponse
{
    public class WorkCategoryDetails
    {
        public string WorkCategoryKey { get; set; }
        public string SourceSystemWorkCategoryId { get; set; }
        public string WorkCategoryName { get; set; }
    }
}