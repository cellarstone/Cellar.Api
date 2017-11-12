using Cellar.Api.Business.Logging.Api;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Cellar.Api.ActionFilters.Common
{
    public class ActionFilterBase : ActionFilterAttribute
    {
        protected readonly ILogManagement Logger;

        public ActionFilterBase(ILogManagement logger)
        {
            Logger = logger;
        }
    }
}
