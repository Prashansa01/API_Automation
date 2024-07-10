using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAutomationHelper.Tests.Interfaces
{
    public interface ITokenService
    {
        Task<string> GetAccessTokenAsync();
    }
}
