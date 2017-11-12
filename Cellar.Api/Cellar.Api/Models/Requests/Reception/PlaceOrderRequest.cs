using Cellar.Api.Models.Requests.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cellar.Api.Models.Requests.Reception
{
    public class PlaceOrderRequest : AuthenticatedPostRequestBase
    {
        [Required]
        public List<OrderItem> Items { get; set; }
    }
}
