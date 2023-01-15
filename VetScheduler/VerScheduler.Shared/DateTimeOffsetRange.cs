using System;
using VetScheduler.VetScheduler.Shared;

namespace VerScheduler.Shared
{
    public class DateTimeOffsetRange : ValueObject
    {
        public DateTimeOffset Start { get; private set; }

        public DateTimeOffset End { get; private set; }

        public DateTimeOffsetRange(DateTimeOffset start, DateTimeOffset end)
        {
            //TODO: Guard against out of range start
            Start = start;
            End = end;
        }

        public DateTimeOffsetRange(DateTimeOffset start, TimeSpan duration)
            : this(start, start.Add(duration))
        {
        }

        public int DurationInMinutes()
        {
            return (int)Math.Round((End - Start).TotalMinutes, 0);
        }

        public DateTimeOffsetRange NewDuration(TimeSpan newDuration)
        {
            return new DateTimeOffsetRange(Start, newDuration);
        }

        public DateTimeOffsetRange NewEnd(DateTimeOffset newEnd)
        {
            return new DateTimeOffsetRange(Start, newEnd);
        }

        public DateTimeOffsetRange NewStart(DateTimeOffset newStart)
        {
            return new DateTimeOffsetRange(newStart, End);
        }

        public static DateTimeOffsetRange CreateOneDayRange(DateTimeOffset day)
        {
            return new DateTimeOffsetRange(day, day.AddDays(1.0));
        }

        public static DateTimeOffsetRange CreateOneWeekRange(DateTimeOffset startDay)
        {
            return new DateTimeOffsetRange(startDay, startDay.AddDays(7.0));
        }

        public bool Overlaps(DateTimeOffsetRange dateTimeRange)
        {
            if (Start < dateTimeRange.End)
            {
                return End > dateTimeRange.Start;
            }

            return false;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Start;
            yield return End;
        }
    }
}
