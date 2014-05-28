using System;
using System.Globalization;

namespace ConsoleApplication1
{
    public static class OrderQueue
    {
        public static void Enqueue(object order)
        {
            return;
        }
    }

    internal class Program
    {
        #region Delegates

        public delegate void LongRunningProcess();

        #endregion

        public static void OrderCheck(object order)
        {
            var holidaySchedule = new UnitedStatesHolidaySchedule(UnitedStatesHolidayScheduleTypes.Federal,
                                                                  DateTime.Today.Year);

            if (holidaySchedule.GetObservedHolidays().Contains(DateTime.Today))
            {
                OrderQueue.Enqueue(order);
            }
            else
            {
                Action action = () => ProcessOrder(order);
                action.BeginInvoke(null, null);
            }
        }

        public static void ProcessOrder(object order)
        {
            //Some process
            return;
        }

        public static void ProcessCheck()
        {
            if (DateTime.Today == DateTime.Today.Get(WeekOfMonth.Last, DayOfWeek.Friday))
            {
                LongRunningProcess longProcess = CloseMonth;
                longProcess.BeginInvoke(null, null);
            }
            else if (DateTime.Today == DateTime.Today.Get(WeekOfMonth.First, DayOfWeek.Monday))
            {
                LongRunningProcess longProcess = PrepStatements;
                longProcess.BeginInvoke(null, null);
            }
            else if (DateTime.Today == DateTime.Today.Get(MonthOfYear.August, WeekOfMonth.Last, DayOfWeek.Saturday))
            {
                LongRunningProcess longProcess = CloseQuarter;
                longProcess.BeginInvoke(null, null);
            }
        }

        public static void CloseMonth()
        {
            //Some long running process
            return;
        }

        public static void PrepStatements()
        {
            //Some long running process
            return;
        }

        public static void CloseQuarter()
        {
            //Some long running process
            return;
        }

        private static void Main(string[] args)
        {
            Console.WriteLine(DateTime.Today);
            var holidaySchedule = new UnitedStatesHolidaySchedule(UnitedStatesHolidayScheduleTypes.Federal, DateTime.Now.Year);
            Console.WriteLine("Getting Holidays");
            foreach (DateTime holiday in holidaySchedule.GetHolidays())
            {
                Console.WriteLine(holiday);
            }
            Console.WriteLine();
            Console.WriteLine("Getting Observed Holidays");
            Console.WriteLine();
            foreach (DateTime holiday in holidaySchedule.GetObservedHolidays())
            {
                Console.WriteLine(holiday);
            }

            Console.WriteLine();
            Console.WriteLine("Very Simple Order check!");
            OrderCheck(new object());
            Console.WriteLine("Very Simple Process check!");
            ProcessCheck();

            Console.WriteLine("Done");
            Console.Read();
        }
    }
}