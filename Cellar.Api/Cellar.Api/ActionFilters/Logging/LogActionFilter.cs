using Cellar.Api.ActionFilters.Common;
using Cellar.Api.Business.Logging.Api;
using CellarControllerBase = Cellar.Api.Controllers.ControllerBase;
using Cellar.Api.Models.Requests.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cellar.Api.ActionFilters.Logging
{
    /// <summary>
    /// Logs all requests and responses from all actions in controller
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class LogActionFilter : ActionFilterBase
    {
        public LogActionFilter(ILogManagement logger) : base(logger)
        {

        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context != null)
            {
                string requestId = null;
                if (context.Controller != null && context.Controller is CellarControllerBase controllerBase)
                {
                    requestId = controllerBase.RequestId;
                }

                string route = null;
                if (context.HttpContext.Request.Path.HasValue)
                {
                    route = context.HttpContext.Request.Path.Value;
                }

                object requestObject = null;
                foreach (var arg in context.ActionArguments)
                {
                    if (arg.Value is RequestBase)
                    {
                        requestObject = arg.Value;
                        break;
                    }
                }
                
                Logger.WriteRequestLog(requestId, context.HttpContext.Request.Method, route, requestObject);
            }
        }

        public override void OnResultExecuted(ResultExecutedContext context)
        {
            if (context != null)
            {
                string requestId = null;
                if (context.Controller != null && context.Controller is CellarControllerBase controllerBase)
                {
                    requestId = controllerBase.RequestId;
                }

                string route = null;
                if (context.HttpContext.Request.Path.HasValue)
                {
                    route = context.HttpContext.Request.Path.Value;
                }

                Logger.WriteResponseLog(requestId, context.HttpContext.Request.Method, route, context.Result);
            }
        }
    }
}
