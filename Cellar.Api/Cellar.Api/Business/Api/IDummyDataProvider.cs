using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cellar.Api.Models;

namespace Cellar.Api.Business.Api
{
    public interface IDummyDataProvider
    {
        RoomInfo GetRoomInfo(string roomId);

        List<MeetingInfo> GetRoomTimeline(string roomId);

        string GetRandomRoomState(string roomId);

        List<CalendarItem> GetRoomCalendar(string roomId, int numberOfItems = 5, int? year = null, int? month = null);


    }
}
