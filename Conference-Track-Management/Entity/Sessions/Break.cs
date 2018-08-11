using System;

namespace Conference_Track_Management.Entity.Sessions
{
    public class Break
    {
        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public string Title { get; set; }
    }

}
