using System;
using System.Collections.Generic;
using System.Linq;
using Conference_Track_Management.Entity;
using Conference_Track_Management.Helper;

namespace Conference_Track_Management
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var talks = new List<Talk>()
            {
                new Talk(){Duration = 60, Name = "Writing Fast Tests Against Enterprise Rails" },
                new Talk(){Duration = 45, Name = "Overdoing it in Python" },
                new Talk(){Duration = 30, Name = "Lua for the Masses" },
                new Talk(){Duration = 45, Name = "Ruby Errors from Mismatched Gem Versions" },
                new Talk(){Duration = 45, Name = "Common Ruby Errors" },
                new Talk(){IsLightning = true, Name = "Rails for Python Developers" },
                new Talk(){Duration = 60, Name = "Communicating Over Distance" },
                new Talk(){Duration = 45, Name = "Accounting-Driven Development" },
                new Talk(){Duration = 30, Name = "Woah" },
                new Talk(){Duration = 30, Name = "Sit Down and Write" },
                new Talk(){Duration = 45, Name = "Pair Programming vs Noise" },
                new Talk(){Duration = 60, Name = "Rails Magic" },
                new Talk(){Duration = 60, Name = "Ruby on Rails: Why We Should Move On" },
                new Talk(){Duration = 45, Name = "Clojure Ate Scala (on my project)" },
                new Talk(){Duration = 30, Name = "Programming in the Boondocks of Seattle" },
                new Talk(){Duration = 30, Name = "Ruby vs. Clojure for Back-End Development" },
                new Talk(){Duration = 60, Name = "Ruby on Rails Legacy App Maintenance" },
                new Talk(){Duration = 30, Name = "A World Without HackerNews" },
                new Talk(){Duration = 30, Name = "User Interface CSS in Rails Apps" },
            };

            var days = new List<Day>()
            {
                new Day()
                {
                    Title = "Track 1"
                },
                new Day() {
                    Title = "Track 2"
                },
            };
            var conf = new Conference(talks, days);
            conf.Scheduler.Schedule();
            new WriterFormat().Format(conf.Days);
        }
    }
}
