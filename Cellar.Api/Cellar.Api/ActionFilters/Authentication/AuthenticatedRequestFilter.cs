using Cellar.Api.Business.Authentication.Api;
using Cellar.Api.Models.Requests.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Cellar.Api.ActionFilters.Authentication
{
    public class AuthenticatedRequestFilter : ActionFilterAttribute
    {
        #region --- injected resources ------------------------------------------------------------
        private readonly IAuthenticationManagement authenticationManagement;
        #endregion

        #region --- ctor --------------------------------------------------------------------------
        public AuthenticatedRequestFilter(IAuthenticationManagement authenticationManagement)
        {
            this.authenticationManagement = authenticationManagement;
        }
        #endregion

        #region --- overridden methods ------------------------------------------------------------
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context != null && context.ModelState.IsValid && context.ActionArguments != null)
            {
                foreach (var arg in context.ActionArguments)
                {
                    if (arg.Value is AuthenticatedPostRequestBase authRequest)
                    {
                        var authenticated = authenticationManagement.ValidatePin(authRequest.Pin);

                        if (!authenticated)
                        {
                            context.HttpContext.Response.StatusCode = 401;
                            context.HttpContext.Response.Headers.Clear();

                            context.Result = new EmptyResult();
                        }
                    }
                }
            }
        }
        #endregion
    }
}
