﻿using Cellar.Api.Business.Api;
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

        #region ReceptionController
        public List<SortimentItem> GetSortiment()
        {
            var list = new List<SortimentItem>
            {
                new SortimentItem
                {
                    Id = "1",
                    Name = "Brownies"
                },
                new SortimentItem
                {
                    Id = "2",
                    Name = "Cookies"
                },
                new SortimentItem
                {
                    Id = "3",
                    Name = "Apple"
                },
                new SortimentItem
                {
                    Id = "4",
                    Name = "Chips"
                },
                new SortimentItem
                {
                    Id = "5",
                    Name = "Tea",
                    ChildItems = new List<SortimentItem>
                    {
                        new SortimentItem
                        {
                            Id = "10",
                            Name = "Green"
                        },
                        new SortimentItem
                        {
                            Id = "11",
                            Name = "Jasmine"
                        },
                        new SortimentItem
                        {
                            Id = "12",
                            Name = "Black"
                        }
                    }
                },
                new SortimentItem
                {
                    Id = "6",
                    Name = "Coffee",
                    ChildItems = new List<SortimentItem>
                    {
                        new SortimentItem
                        {
                            Id = "13",
                            Name = "Espresso"
                        },
                        new SortimentItem
                        {
                            Id = "14",
                            Name = "Lungo"
                        },
                        new SortimentItem
                        {
                            Id = "15",
                            Name = "Americano"
                        },
                        new SortimentItem
                        {
                            Id = "15",
                            Name = "Latte"
                        },
                        new SortimentItem
                        {
                            Id = "15",
                            Name = "Cappuccino"
                        }
                    }
                },
                new SortimentItem
                {
                    Id = "7",
                    Name = "Water"
                },
                new SortimentItem
                {
                    Id = "8",
                    Name = "Coca-Cola"
                },
                new SortimentItem
                {
                    Id = "9",
                    Name = "Chewing gum"
                }
            };


            return list;
        }
        #endregion
    }
}
