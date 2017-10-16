using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cellar.Api.Models.Requests.Reception
{
    public class OrderItem
    {
        public string SortimentItemId { get; set; }

        public int Count { get; set; }
    }
}
