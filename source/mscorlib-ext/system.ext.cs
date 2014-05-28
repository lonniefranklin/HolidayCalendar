/*
Copyright 2014 Lonnie Franklin

This file is part HolidayCalendar.

HolidayCalendar is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

HolidayCalendar is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with HolidayCalendar. If not, see http://www.gnu.org/licenses/.
 */
namespace System
{
    /// <summary>
    /// 
    /// </summary>
    public static partial class Extensions
    {
        #region DateTime Extensions
        /// <summary>
        /// Gets the next date from the year, month and day of current value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="dayOfWeek">The day of week.</param>
        /// <returns></returns>
        public static DateTime Get(this DateTime value, DayOfWeek dayOfWeek)
        {
            var e = (int)dayOfWeek;
            var s = (int)value.DayOfWeek;

            return s < e ? value.AddDays(e - s) : value.AddDays(-(s - e)).AddDays(7);
        }

        /// <summary>
        /// Gets the next date from the year and month of current date.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="weekOfMonth">The week of month.</param>
        /// <param name="dayOfWeek">The day of week.</param>
        /// <returns></returns>
        public static DateTime Get(this DateTime value, WeekOfMonth weekOfMonth, DayOfWeek dayOfWeek)
        {
            var startDate = new DateTime(value.Year, value.Month, 1);
            var date = startDate;
            var i = (int)weekOfMonth;

            if (date.DayOfWeek == dayOfWeek && weekOfMonth == WeekOfMonth.First)
                return date;

            if (date.DayOfWeek == dayOfWeek)
                return date.AddDays((int)weekOfMonth * 7);

            var e = (int)dayOfWeek;
            var s = (int)date.DayOfWeek;

            if (s < e)
                date = date.AddDays(e - s);
            else
            {
                date = date.AddDays(-s);

                if (date.Month != startDate.Month)
                    i++;

                date = date.AddDays(e);
            }

            date = date.AddDays(i * 7);

            return date.Month != startDate.Month ? date.AddDays(-7) : date;
        }

        /// <summary>
        /// Gets the next date from the year of current date.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="monthOfYear">The month of year.</param>
        /// <param name="weekOfMonth">The week of month.</param>
        /// <param name="dayOfWeek">The day of week.</param>
        /// <returns></returns>
        public static DateTime Get(this DateTime value, MonthOfYear monthOfYear, WeekOfMonth weekOfMonth, DayOfWeek dayOfWeek)
        {
            var dateTime = new DateTime(value.Year, (int)monthOfYear + 1, 1);
            return dateTime.Get(weekOfMonth, dayOfWeek);
        }

        /// <summary>
        /// Gets the next date.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="year">The year.</param>
        /// <param name="monthOfYear">The month of year.</param>
        /// <param name="weekOfMonth">The week of month.</param>
        /// <param name="dayOfWeek">The day of week.</param>
        /// <returns></returns>
        public static DateTime Get(this DateTime value, int year, MonthOfYear monthOfYear, WeekOfMonth weekOfMonth, DayOfWeek dayOfWeek)
        {
            var dateTime = new DateTime(year, (int)monthOfYear + 1, 1);
            return dateTime.Get(weekOfMonth, dayOfWeek);
        }

        /// <summary>
        /// Gets the week of month.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static WeekOfMonth GetWeekOfMonth(this DateTime value)
        {
            var i = 0;
            var w = 0;
            var date = new DateTime(value.Year, value.Month, value.Day);            

            while (date < value)
            {
                if (i == 7)
                {
                    w++;
                    i = 0;
                }

                date = date.AddDays(1);
                i++;
            }

            return (WeekOfMonth)w;
        }

        /// <summary>
        /// Determines whether the date is on the weekend.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// 	<c>true</c> if the specified value is weekend; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsWeekend(this DateTime value)
        {
            return value.DayOfWeek == DayOfWeek.Sunday || value.DayOfWeek == DayOfWeek.Saturday;
        }

        #endregion
            
    }
}

