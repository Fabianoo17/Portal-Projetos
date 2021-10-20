using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Core.Business.Helpers
{
    public class ServerHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ServerHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public bool IsEnvironmentDevLocalhost()
        {
            var host = _httpContextAccessor.HttpContext.Request.Host;

            if (host.Host.Contains("localhost"))
                return true;

            return false;
        }

        public bool IsEnvironmentDev()
        {
            var host = _httpContextAccessor.HttpContext.Request.Host;

            if (host.Host.Contains("localhost")
                || host.Host.Contains(".hom.")
                || host.Host.Contains(".hmp.")
                || host.Host.Contains(".des."))
                return true;

            return false;
        }
    }
}
