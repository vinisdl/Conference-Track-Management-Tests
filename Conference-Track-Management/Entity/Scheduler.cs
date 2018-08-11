using System;
using System.Collections.Generic;
using System.Linq;
using Conference_Track_Management.Entity.Sessions;

namespace Conference_Track_Management.Entity
{
    public class Scheduler
    {
        private readonly List<Day> _days;
        private List<Talk> _talks;

        public Scheduler(List<Day> days, List<Talk> talks)
        {
            _days = days;
            _talks = talks;
        }

        public void Schedule()
        {
            SortTalks();
            InitializeDays();
            ScheduleTalksInDays();
            ScheduleNetworkingEvent(_days);
        }

        #region Private Methods

        private void SortTalks()
        {
            _talks = _talks.OrderByDescending(t => t.Duration).ToList();
        }

        private void ScheduleTalksInDays()
        {
            var talks = new List<Talk>();
            foreach (var day in _days)
            foreach (var talk in _talks.Where(a => !talks.Select(t => t.Name).Contains(a.Name)))
                ScheduleTalkInDay(talks, talk, day);
        }

        #region Pivate Static Methods

        private static void ScheduleTalkInDay(ICollection<Talk> talks, Talk talk, Day day)
        {
            var isScheduledInMorning = ScheduleInMorning(talk, day);

            if (!isScheduledInMorning)
            {
                if (ScheduleInEvening(talk, day))
                    talks.Add(talk);
            }
            else
            {
                talks.Add(talk);
            }
        }

        private static void ScheduleNetworkingEvent(IEnumerable<Day> days)
        {
            foreach (var track in days)
                track.Networking.StartTime = track.EveningSession.EndTime - track.EveningSession.TimeRemaining;
        }

        private void InitializeDays()
        {
            foreach (var day in _days)
            {
                day.MorningSession.Talks = new List<Talk>();
                day.MorningSession.TimeRemaining =
                    day.MorningSession.EndTime.Subtract(day.MorningSession.StartTime);

                day.EveningSession.Talks = new List<Talk>();
                day.EveningSession.TimeRemaining =
                    day.EveningSession.EndTime.Subtract(day.EveningSession.StartTime);
            }
        }

        private static bool ScheduleInMorning(Talk talk, Day day)
        {
            if (!TalkCanBeScheduled(talk.Duration, day.MorningSession))
                return false;
            day.MorningSession.Talks.Add(talk);
            day.MorningSession.TimeRemaining = day.MorningSession
                .TimeRemaining.Subtract(new TimeSpan(0, talk.Duration, 0));
            return true;
        }

        private static bool ScheduleInEvening(Talk talk, Day day)
        {
            if (!TalkCanBeScheduled(talk.Duration, day.EveningSession))
                return false;
            day.EveningSession.Talks.Add(talk);
            day.EveningSession.TimeRemaining = day.EveningSession.TimeRemaining - new TimeSpan(0, talk.Duration, 0);
            return true;
        }

        private static bool TalkCanBeScheduled(int duration, TalkSession talkSession)
        {
            return duration <= talkSession.TimeRemaining.TotalMinutes;
        }

        #endregion

        #endregion
    }
}