using System;
using System.Collections.Generic;
using System.Globalization;
using Conference_Track_Management.Entity;

namespace Conference_Track_Management.Helper
{
    public class WriterFormat
    {
        public WriterFormat()
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
        }

        public void Format(IEnumerable<Day> days)
        {
            foreach (var day in days)
            {
                Console.WriteLine(day.Title);
                Console.WriteLine($"  {day.MorningSession.Title}");
                var currentTime = day.MorningSession.StartTime;

                WriteMorningTalks(day, currentTime);

                Console.WriteLine();
                Console.WriteLine($"  {DateTime.Today.Add(day.LunchBreak.StartTime):HH:mm tt} {day.LunchBreak.Title}");
                Console.WriteLine();

                Console.WriteLine($"  {day.EveningSession.Title}");
                currentTime = day.EveningSession.StartTime;

                WriteEveningTalks(day, currentTime);

                Console.WriteLine($"  {DateTime.Today.Add(day.Networking.StartTime):HH:mm tt} {day.Networking.Title} ");
                Console.WriteLine();
            }
        }

        private static void WriteEveningTalks(Day day, TimeSpan currentTime)
        {
            foreach (var talk in day.EveningSession.Talks)
            {
                Console.WriteLine($"  {DateTime.Today.Add(currentTime):HH:mm tt} {talk.Name} {talk.Duration}min");
                currentTime =
                    currentTime.Add(new TimeSpan(0, talk.Duration, 0));
            }
        }

        private static void WriteMorningTalks(Day day, TimeSpan currentTime)
        {
            foreach (var talk in day.MorningSession.Talks)
            {
                Console.WriteLine($"  {DateTime.Today.Add(currentTime):HH:mm tt} {talk.Name} {talk.Duration}min");
                currentTime =
                    currentTime.Add(new TimeSpan(0, talk.Duration, 0));
            }
        }
    }
}