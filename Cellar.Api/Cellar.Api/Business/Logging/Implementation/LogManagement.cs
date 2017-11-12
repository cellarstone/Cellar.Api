using Cellar.Api.Business.Logging.Api;
using Cellar.Api.DataAccess.Api.Repository;
using Cellar.Api.DataAccess.Domain;
using Cellar.Api.DataAccess.Enum;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cellar.Api.Business.Logging.Implementation
{
    public class LogManagement : ILogManagement
    {
        #region --- injected resources ------------------------------------------------------------
        private readonly IActionLogsRepository actionLogsRepository;
        #endregion
        
        #region --- ctor --------------------------------------------------------------------------
        public LogManagement(IActionLogsRepository actionLogsRepository)
        {
            this.actionLogsRepository = actionLogsRepository;
        }
        #endregion

        #region --- ILogManagement members --------------------------------------------------------
        public bool WriteRequestLog(string requestId, string requestMethod, string route, object request)
        {
            var result = WriteActionLog(requestId, requestMethod, route, ActionLogTypes.Request, request);

            return result;
        }

        public bool WriteResponseLog(string requestId, string requestMethod, string route, object response)
        {            
            var result = WriteActionLog(requestId, requestMethod, route, ActionLogTypes.Response, response);

            return result;
        }
        #endregion

        #region --- private methods ---------------------------------------------------------------
        private bool WriteActionLog(string requestId, string requestMethod, string route, string logType, object data)
        {
            string logBody = null;
            if (data != null)
            {
                logBody = JsonConvert.SerializeObject(data);
            }

            var log = new BdoActionLog
            {
                RequestId = requestId,
                RequestMethod = requestMethod,
                ActionRoute = route,
                LogLevel = LogLevelTypes.Info,
                LogType = logType,
                LogBody = logBody
            };

            var result = actionLogsRepository.Add(log);

            return result;
        }
        #endregion
    }
}
