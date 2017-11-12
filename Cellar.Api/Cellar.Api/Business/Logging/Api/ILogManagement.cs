using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cellar.Api.Business.Logging.Api
{
    public interface ILogManagement
    {
        bool WriteRequestLog(string requestId, string requestMethod, string route, object request);

        bool WriteResponseLog(string requestId, string requestMethod, string route, object response);
    }
}
