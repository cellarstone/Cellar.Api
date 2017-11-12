using Cellar.Api.Models.Requests.Common;
using System.ComponentModel.DataAnnotations;

namespace Cellar.Api.Models.Requests.Reception
{
    public class ValidatePinRequest : RequestBase
    {
        /// <summary>
        /// PIN code for validation
        /// </summary>
        [Required]
        public string Pin { get; set; }
    }
}