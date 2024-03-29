﻿using Cellar.Api.Models.Requests.Common;
using System.ComponentModel.DataAnnotations;

namespace Cellar.Api.Models.Requests.Reception
{
    public class SomethingElseRequest : AuthenticatedPostRequestBase
    {
        /// <summary>
        /// Message for reception
        /// </summary>
        [Required]
        public string Message { get; set; }
    }
}