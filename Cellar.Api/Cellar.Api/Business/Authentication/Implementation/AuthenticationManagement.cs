using Cellar.Api.Business.Authentication.Api;

namespace Cellar.Api.Business.Authentication.Implementation
{
    public class AuthenticationManagement : IAuthenticationManagement
    {
        public bool ValidatePin(string pin)
        {
            return pin == "1234";
        }
    }
}
