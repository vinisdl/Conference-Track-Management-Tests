using System;
using System.Collections.Generic;

namespace Conference_Track_Management.Entity.Sessions
{
    public class TalkSession : Break
    {
        public List<Talk> Talks { get; set; }

        public TimeSpan TimeRemaining { get; set; }

    }
}
