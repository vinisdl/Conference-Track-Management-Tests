using System;
using System.Collections.Generic;
using System.Text;
using Conference_Track_Management.Entity.Sessions;

namespace Conference_Track_Management.Entity
{
    public class Day
    {
        public string Title { get; set; }
        public MorningSession MorningSession = new MorningSession()
        {
            Title = "Morning Session",
            StartTime = new TimeSpan(09, 00, 00),
            EndTime = new TimeSpan(12, 00, 00)
        };

        public EveningSession EveningSession = new EveningSession()
        {
            Title = "Evening Session",
            StartTime = new TimeSpan(13, 00, 00),
            EndTime = new TimeSpan(17, 00, 00)
        };

        public NetworkingEvent Networking = new NetworkingEvent()
        {
            Title = "Networking Event",
            StartTimeFrom = new TimeSpan(16, 00, 00),
            StartTimeTo = new TimeSpan(17, 00, 00)
        };

        public Break LunchBreak = new Break()
        {
            Title = "Lunch Break",
            StartTime = new TimeSpan(12, 00, 00),
            EndTime = new TimeSpan(13, 00, 00)
        };
    }
}
