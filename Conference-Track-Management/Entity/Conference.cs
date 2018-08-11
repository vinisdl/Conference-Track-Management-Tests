using System;
using System.Collections.Generic;
using System.Text;

namespace Conference_Track_Management.Entity
{
    public class Conference
    {
        public List<Talk> Talks { get; set; }
        public Scheduler Scheduler { get; set; }

        public List<Day> Days { get; set; }

        public Conference(List<Talk> talks, List<Day> days)
        {
            Talks = talks;
            Days = days;
            Scheduler = new Scheduler(days, talks);
        }
    }

  
}
