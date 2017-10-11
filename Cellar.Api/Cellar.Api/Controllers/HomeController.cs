using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Cellar.Api.Models;

namespace Cellar.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Home")]
    public class HomeController : ControllerBase
    {
        [HttpGet("{roomId}")]
        [Route("GetRoomInfo/{roomId}")]
        public RoomInfo GetRoomInfo(string roomId)
        {
            var roomInfo = DummyDataProvider.GetRoomInfo(roomId);

            return roomInfo;
        }

        [HttpGet("{roomId}")]
        [Route("GetRoomTimeline/{roomId}")]
        public List<MeetingInfo> GetRoomTimeline(string roomId)
        {
            var timeline = DummyDataProvider.GetRoomTimeline(roomId);

            return timeline;
        }

        [HttpGet("{roomId}")]
        [Route("GetRoomState/{roomId}")]
        public string GetRoomState(string roomId)
        {
            var state = DummyDataProvider.GetRandomRoomState(roomId);

            return state;
        }
    }
}