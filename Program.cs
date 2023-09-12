using ScheduleGeneratorPractice;

namespace RecurringScheduleGenerator
{
    public class Program
    {
        public class Row
        {
            public int Id1;
            public int Id2;
            public int Value;
        }
        static void Main(string[] args)
        {

//            List<Row> rows = new List<Row>(){
//    new Row(){Id1=1,Id2=9,Value=12},
//    new Row(){Id1=2,Id2=9,Value=6},
//    new Row(){Id1=3,Id2=11,Value=8},
//    new Row(){Id1=4,Id2=11,Value=87}
//};
//            var res = rows.GroupBy(r => r.Id2)
//                                .Select(g => g.ToList());

//            //EventGeneratorUsingIcal.GenerateRecurringEvents();
//            Console.WriteLine("Recurring Schedule:");
//            foreach (DateTime eventDate in EventGeneratorUsingIcal.GenerateRecurringEvents())
//            {
//                Console.WriteLine(eventDate.ToString("ddd, dd MMMM h:mmtt"));
//            }

            DateTime startDate = new DateTime(2023, 9, 1, 16, 0, 0).AddDays(-1);
            DateTime endDate = new DateTime(2023, 9, 29);
            //DateTime endDate = DateTime.Today.AddDays(1);

            List<DayOfWeek> daysOfWeek = new List<DayOfWeek>
            {
                //DayOfWeek.Monday//,
                DayOfWeek.Monday, DayOfWeek.Wednesday//, DayOfWeek.Tuesday, DayOfWeek.Wednesday//, DayOfWeek.Friday
            }.OrderBy(x => x)
            .ToList();

            int intervalInWeeks = 2;

            List<DateTime> schedule = GenerateRecurringSchedule(startDate, endDate, daysOfWeek, intervalInWeeks);

            Console.WriteLine("Recurring Schedule:");
            foreach (DateTime eventDate in schedule)
            {
                Console.WriteLine(eventDate.ToString("ddd, dd MMMM h:mmtt"));
            }
        }

        public static List<DateTime> GenerateRecurringSchedule(DateTime startDate, DateTime endDate, List<DayOfWeek> daysOfWeek, int intervalInWeeks)
        {
            List<DateTime> schedule = new List<DateTime>();
            DateTime currentDate = startDate;
            var lastDayOfWeek = currentDate.EndOfWeek(DayOfWeek.Saturday);
            while (!daysOfWeek.Contains(currentDate.DayOfWeek))
            {
                currentDate = currentDate.AddDays(1);
            }
            var dateDiff = (currentDate.EndOfWeek(DayOfWeek.Saturday) - currentDate).TotalDays;
            for (int i = 0; i < dateDiff; i++)
            {
                if(daysOfWeek.Contains(currentDate.DayOfWeek) && lastDayOfWeek > currentDate) 
                    schedule.Add(currentDate);

                currentDate = currentDate.AddDays(1);
                if(currentDate > endDate)
                {
                    return schedule;
                }
            }
            if (daysOfWeek.Contains(currentDate.DayOfWeek))
                schedule.Add(currentDate);
            currentDate = startDate.AddDays(7 * intervalInWeeks).StartOfWeek(DayOfWeek.Sunday);

            if (currentDate > endDate)
            {
                return schedule;
            }
            while (currentDate <= endDate)
            {
                foreach (DayOfWeek dayOfWeek in daysOfWeek)
                {
                    while (currentDate.DayOfWeek != dayOfWeek)
                    {
                        currentDate = currentDate.AddDays(1);
                    }

                    schedule.Add(currentDate);
                    currentDate = currentDate.AddDays(1);
                    if (currentDate > endDate)
                    {
                        return schedule;
                    }
                }

                currentDate = currentDate.AddDays(-7).AddDays(7 * intervalInWeeks);
            }
            return schedule;
        }
    }
}
