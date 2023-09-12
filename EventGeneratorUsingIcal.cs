
using Ical.Net;
using Ical.Net.CalendarComponents;
using Ical.Net.DataTypes;
using Ical.Net.Evaluation;
using Ical.Net.Serialization;

namespace ScheduleGeneratorPractice
{
    public static class EventGeneratorUsingIcal
    {
        public static List<DateTime> GenerateRecurringEvents()
        {
            // Set the timezone
            //var timezone = TimeZoneInfo.FindSystemTimeZoneById("Australia/Brisbane");
            var timezone = "Australia/Sydney";

            // Create a new calendar
            var calendar = new Calendar();

            // Create a recurring event
            var recurringEvent = new CalendarEvent
            {
                Summary = "Weekly Recurring Event",
                Description = "Description of the recurring event",
                Start = new CalDateTime(new DateTime(2023, 8, 12, 15, 0, 0), timezone),
                End = new CalDateTime(new DateTime(2023, 8, 12, 16, 0, 0), timezone),
                IsAllDay = false,
            };

            // Set the recurrence rule
            var recurrenceRule = new RecurrencePattern(FrequencyType.Weekly, 2)
            {
                Until = new DateTime(2023, 12, 31, 13, 59, 59),
            };
            recurrenceRule.ByDay.Add(new WeekDay(DayOfWeek.Sunday));
            recurrenceRule.ByDay.Add(new WeekDay(DayOfWeek.Monday));
            recurrenceRule.ByDay.Add(new WeekDay(DayOfWeek.Saturday));
            recurringEvent.RecurrenceRules.Add(recurrenceRule);

            // Add the event to the calendar
            calendar.Events.Add(recurringEvent);
            var occurrences2 = calendar.GetOccurrences(recurringEvent.Start, new CalDateTime(recurrenceRule.Until, timezone))
                .Select(o => new { Local = o.Period.StartTime, Utc = o.Period.StartTime.AsUtc })
                .OrderBy(o => o.Local)
                .ToList();

            var occurrences = calendar.GetOccurrences(recurringEvent.Start, new CalDateTime(recurrenceRule.Until, timezone));

            // Serialize and print the calendar
            var serializer = new CalendarSerializer();
            var serializedCalendar = serializer.SerializeToString(calendar);
            Console.WriteLine(serializedCalendar);


            // 3/1/2017 is a wednesday so it shouldn't display in the occurrences
            var recurrenceEvaluator = new RecurrencePatternEvaluator(recurrenceRule);
            var searchStart = new DateTime(2017, 3, 1, 0, 0, 0);
            var searchEnd = new DateTime(2023, 12, 31, 13, 59, 59);
            var correctOccurrences = recurrenceEvaluator.Evaluate(recurringEvent.DtStart, searchStart, searchEnd, false);

            return occurrences2.Select(p=>p.Local.Date).ToList();


            //// Create a new calendar
            //var calendar = new Calendar();

            //// Create a recurring event
            //var recurringEvent = new RecurringComponent();
            //recurringEvent.Summary = "Recurring Event";
            //recurringEvent.Description = "Description of the recurring event";
            //recurringEvent.Start = new CalDateTime(new DateTime(2023, 8, 12, 15, 0, 0), timezone);
            //recurringEvent.End = new CalDateTime(new DateTime(2023, 8, 12, 16, 0, 0), timezone);

            //// Set the recurrence rule
            //var rrule = new RecurrencePattern(FrequencyType.Weekly, 2);
            //rrule.Until = new CalDateTime(new DateTime(2023, 12, 31, 13, 59, 59), timezone);
            //rrule.ByDay.Add(new WeekDay(DayOfWeek.Saturday, DayOfWeek.Monday, DayOfWeek.Sunday));
            //recurringEvent.RecurrenceRules.Add(rrule);

            //// Add the event to the calendar
            //calendar.Events.Add(recurringEvent);

            //// Serialize and print the calendar
            //var serializer = new CalendarSerializer();
            //var serializedCalendar = serializer.SerializeToString(calendar);
            //Console.WriteLine(serializedCalendar);
        }

    }
}
