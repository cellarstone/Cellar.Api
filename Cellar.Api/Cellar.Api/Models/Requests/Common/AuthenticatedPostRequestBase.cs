using System.ComponentModel.DataAnnotations;

namespace Cellar.Api.Models.Requests.Common
{
    public class AuthenticatedPostRequestBase : RequestBase
    {
        [Required]
        public string Pin { get; set; }
    }
}
