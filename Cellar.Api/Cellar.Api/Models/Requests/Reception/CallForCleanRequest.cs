using Cellar.Api.Models.Requests.Common;
using System.ComponentModel.DataAnnotations;

namespace Cellar.Api.Models.Requests.Reception
{
    public class CallForCleanRequest : RequestBase
    {
        /// <summary>
        /// Selected type of clean
        /// </summary>
        [Required]
        public string CleanType { get; set; }
    }
}
