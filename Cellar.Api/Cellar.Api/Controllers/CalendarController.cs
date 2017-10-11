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
    [Route("api/Calendar")]
    public class CalendarController : ControllerBase
    {

        [HttpGet("{roomId}")]
        [Route("GetRoomCalendar/{roomId}")]
        public List<CalendarItem> GetRoomCalendar(string roomId)
        {
            var roomCalendar = DummyDataProvider.GetRoomCalendar(roomId);

            return roomCalendar;
        }

        [HttpGet("{year},{month},{roomId}")]
        [Route("GetRoomCalendar/{year}/{month}/{roomId}")]
        public List<CalendarItem> GetRoomCalendar(int year, int month, string roomId)
        {
            var roomCalendar = DummyDataProvider.GetRoomCalendar(roomId, 10, year, month);

            return roomCalendar;
        }

        [HttpGet("{roomId}")]
        [Route("GetDayInfo/{year}/{month}/{day}/{roomId}")]
        public DayInfo GetDayInfo(int year, int month, int day, string roomId)
        {
            var dayInfo = new DayInfo
            {
                Meetings = DummyDataProvider.GetRoomTimeline(roomId)
            };

            return dayInfo;
        }

        [HttpGet("{meetingId}")]
        [Route("GetMeetingInfo/{meetingId}")]
        public MeetingInfo GetMeetingInfo(string meetingId)
        {
            var meetingInfo = new MeetingInfo
            {
                Author = "Jan Novák",
                MeetingStart = DateTime.Now,
                MeetingEnd = DateTime.Now.AddHours(1)
            };

            return meetingInfo;
        }

        [HttpPost]
        [Route("AddNewMeeting")]
        public bool AddNewMeeting([FromBody]string value)
        {
            //DateTime start, DateTime end, string name, string author, string roomId

            return true;
        }
        
        [HttpPut("{meetingId}")]
        [Route("UpdateMeeting/{meetingId}")]
        public bool UpdateMeeting(string meetingId, [FromBody]string value)
        {
            //DateTime start, DateTime end, string name, string author, string roomId

            return true;
        }

        [HttpDelete("{meetingId}")]
        [Route("DeleteMeeting/{meetingId}")]
        public bool DeleteMeeting(string meetingId)
        {

            return true;
        }
    }
}