namespace Cellar.Api.Business.Authentication.Api
{
    public interface IAuthenticationManagement
    {
        bool ValidatePin(string pin);
    }
}
