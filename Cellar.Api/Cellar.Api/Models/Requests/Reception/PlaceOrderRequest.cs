using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cellar.Api.Models.Requests.Reception
{
    public class PlaceOrderRequest
    {
        public List<OrderItem> Items { get; set; }
    }
}
