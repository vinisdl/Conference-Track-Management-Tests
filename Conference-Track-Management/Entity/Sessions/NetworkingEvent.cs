using System;

namespace Conference_Track_Management.Entity.Sessions
{
    public class NetworkingEvent : Break
    {
        public TimeSpan StartTimeFrom { get; set; }

        public TimeSpan StartTimeTo { get; set; }
    }

}
