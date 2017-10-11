using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cellar.Api.Models
{
    public class RoomInfo
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string State { get; set; }

        public MeetingInfo ActualMeeting { get; set; }
    }
}
