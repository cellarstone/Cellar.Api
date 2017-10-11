using Cellar.Api.Business.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cellar.Api.Models;

namespace Cellar.Api.Business.Implementation
{
    public class DummyDataProvider : IDummyDataProvider
    {

        #region HomeController
        public string GetRandomRoomState(string roomId)
        {
            var rnd = new Random();

            return rnd.Next(0, 1) == 0 ? "AVAILABLE" : "OCCUPIED";
        }

        public List<CalendarItem> GetRoomCalendar(string roomId, int numberOfItems = 5, int? year = null, int? month = null)
        {
            var date = (year != null && month != null) ? new DateTime(year.Value, month.Value, 5) : DateTime.Now;

            var rnd = new Random();
            var list = new List<CalendarItem>();
            for (var i = 0; i < numberOfItems; i++)
            {
                list.Add(new CalendarItem { Date = DateTime.Now.AddDays(i), MeetingCount = rnd.Next(1, 15) });
            }
            return list;
        }

        public RoomInfo GetRoomInfo(string roomId)
        {
            return new RoomInfo
            {
                Id = roomId,
                Name = "Jupiter",
                State = "AVAILABLE"
            };
        }

        public List<MeetingInfo> GetRoomTimeline(string roomId)
        {
            var list = new List<MeetingInfo>
            {
                new MeetingInfo {MeetingStart = DateTime.Now, MeetingEnd = DateTime.Now.AddHours(1), Author = "Deneris Targarian"},
                new MeetingInfo {MeetingStart = DateTime.Now.AddHours(1), MeetingEnd = DateTime.Now.AddHours(2), Author = "Jon Snow"},
                new MeetingInfo {MeetingStart = DateTime.Now.AddHours(2), MeetingEnd = DateTime.Now.AddHours(3), Author = "Hodor"},
                new MeetingInfo {MeetingStart = DateTime.Now.AddHours(3), MeetingEnd = DateTime.Now.AddHours(4), Author = "Grey Worm"},
                new MeetingInfo {MeetingStart = DateTime.Now.AddHours(4), MeetingEnd = DateTime.Now.AddHours(5), Author = "Sansa Stark"}
            };

            return list;
        }
        #endregion
    }
}
