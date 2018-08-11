using System;
using System.Collections.Generic;
using System.Linq;
using Conference_Track_Management.Entity;
using Xunit;

namespace Conference_Track_Management_Tests
{
    public class ConferenceTests
    {
        private readonly List<Talk> _talks = new List<Talk>()
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

        private Conference conf;


        public ConferenceTests()
        {
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
            conf = new Conference(_talks, days);
            conf.Scheduler.Schedule();
        }

        [Fact]
        public void TalksHasBeenConfigured()
        {
            Assert.Equal(_talks.Count, conf.Talks.Count);
        }

        [Fact]
        public void DaysConfScheduledTotalTaks()
        {
            Assert.Equal(GetTotalDaysTalks(), _talks.Count);
        }

        [Fact]
        public void DaysConfRespectMorningTime()
        {
            foreach (var confDay in conf.Days)
            {
                var morningDuration = (confDay.MorningSession.EndTime - confDay.MorningSession.StartTime).TotalMinutes;
                Assert.True(confDay.MorningSession.Talks.Sum(a => a.Duration) <= morningDuration);
            }
        }

        [Fact]
        public void DaysConfRespectEveningTime()
        {
            foreach (var confDay in conf.Days)
            {
                var eveningDuration = (confDay.EveningSession.EndTime - confDay.EveningSession.StartTime).TotalMinutes;
                Assert.True(confDay.EveningSession.Talks.Sum(a => a.Duration) <= eveningDuration);
            }
        }

        [Fact]
        public void TalksDoNotRepeatThemselves()
        {
            var alltaks = GetAllScheduledConferenceTalks();
            Assert.True(alltaks.Select(a => a.Name).Distinct().Count() == alltaks.Count());
        }

        [Fact]
        public void AllTalksScheduled()
        {
            var alltaks = GetAllScheduledConferenceTalks().Select(a => a.Name);
            Assert.True(_talks.TrueForAll(t => alltaks.Contains(t.Name)));
        }

        private List<Talk> GetAllScheduledConferenceTalks()
        {
            var alltaks = new List<Talk>();
            foreach (var confDay in conf.Days)
            {
                alltaks.AddRange(confDay.MorningSession.Talks);
                alltaks.AddRange(confDay.EveningSession.Talks);
            }

            return alltaks;
        }

        private int GetTotalDaysTalks()
        {
            return conf.Days.Sum(day => day.EveningSession.Talks.Count + day.MorningSession.Talks.Count);
        }
    }
}
