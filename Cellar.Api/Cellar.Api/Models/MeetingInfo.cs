using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cellar.Api.Models
{
    public class MeetingInfo
    {
        public DateTime MeetingStart { get; set; }

        public DateTime MeetingEnd { get; set; }

        public string Author { get; set; }
    }
}
