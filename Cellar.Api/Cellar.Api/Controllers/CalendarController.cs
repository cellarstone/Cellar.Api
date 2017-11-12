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

        [HttpGet("GetRoomCalendar/{roomId}")]
        [Route("GetRoomCalendar/{roomId}")]
        public IActionResult GetRoomCalendarAAA([FromQuery]string roomId)
        {
            var roomCalendar = DummyDataProvider.GetRoomCalendar(roomId);

            return Ok(roomCalendar);
        }

        [HttpGet("{year},{month},{roomId}")]
        [Route("GetRoomCalendar/{year}/{month}/{roomId}")]
        public IActionResult GetRoomCalendarBBB(int year, int month, string roomId)
        {
            var roomCalendar = DummyDataProvider.GetRoomCalendar(roomId, 10, year, month);

            return Ok(roomCalendar);
        }

        [HttpGet("{roomId}")]
        [Route("GetDayInfo/{year}/{month}/{day}/{roomId}")]
        public IActionResult GetDayInfo(int year, int month, int day, string roomId)
        {
            var dayInfo = new DayInfo
            {
                Meetings = DummyDataProvider.GetRoomTimeline(roomId)
            };

            return Ok(dayInfo);
        }

        [HttpGet("{meetingId}")]
        [Route("GetMeetingInfo/{meetingId}")]
        public IActionResult GetMeetingInfo(string meetingId)
        {
            var meetingInfo = new MeetingInfo
            {
                Author = "Jan Novák",
                MeetingStart = DateTime.Now,
                MeetingEnd = DateTime.Now.AddHours(1)
            };

            return Ok(meetingInfo);
        }

        [HttpPost]
        [Route("AddNewMeeting")]
        public IActionResult AddNewMeeting([FromBody]string value)
        {
            //DateTime start, DateTime end, string name, string author, string roomId

            return Ok(true);
        }
        
        [HttpPut("{meetingId}")]
        [Route("UpdateMeeting/{meetingId}")]
        public IActionResult UpdateMeeting(string meetingId, [FromBody]string value)
        {
            //DateTime start, DateTime end, string name, string author, string roomId

            return Ok(true);
        }

        [HttpDelete("{meetingId}")]
        [Route("DeleteMeeting/{meetingId}")]
        public IActionResult DeleteMeeting(string meetingId)
        {

            return Ok(true);
        }
    }
}