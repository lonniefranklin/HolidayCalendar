/*
Copyright 2014 Lonnie Franklin

This file is part HolidayCalendar.

HolidayCalendar is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

HolidayCalendar is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with HolidayCalendar. If not, see http://www.gnu.org/licenses/.
 */
namespace System.Globalization
{
    /// <summary>
    /// 
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// Gets the observed day.  
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static DateTime GetObservedDay(this DateTime value)
        {
            var date = new DateTime(value.Year, value.Month, value.Day);

            switch (value.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    date = date.AddDays(1);
                    break;
                case DayOfWeek.Saturday:
                    date = date.AddDays(-1);
                    break;
            }

            return date;
        }

        /// <summary>
        /// Gets Good Friday.
        /// </summary>
        /// <value>The good friday.</value>
        public static DateTime GetGoodFriday(this GregorianCalendar value, int year)
        {
            return value.GetEaster(year).AddDays(-2);
        }

        /// <summary>
        /// Gets Easter Sunday.
        /// As noted on : http://www.assa.org.au/edm.html#Computer.
        /// Slightly modified for C#.
        /// </summary>
        /// <value>The Easter Sunday.</value>
        public static DateTime GetEaster(this GregorianCalendar value, int year)
        {
            // EASTER DATE CALCULATION FOR YEARS 1583 TO 4099

            //first 2 digits of year
            int firstDig = year / 100;
            //remainder of year / 19
            int remain19 = year % 19;

            // calculate PFM date
            int temp = (firstDig - 15) / 2 + 202 - 11 * remain19;

            switch (firstDig)
            {
                case 21:
                case 24:
                case 25:
                case 27:
                case 28:
                case 29:
                case 30:
                case 31:
                case 32:
                case 34:
                case 35:
                case 38:
                    temp = temp - 1;
                    break;
                case 33:
                case 36:
                case 37:
                case 39:
                case 40:
                    temp = temp - 2;
                    break;
            }
            temp = temp % 30;

            //table A to E results
            int tA = temp + 21;
            if ((temp == 29) || (temp == 28 & remain19 > 10))
                tA -= 1;

            int tB = (tA - 19) % 7;

            int tC = (40 - firstDig) % 4;
            if (tC == 3 || tC > 1)
                tC++;

            temp = year % 100;
            int tD = (temp + temp / 4) % 7;

            int tE = ((20 - tB - tC - tD) % 7) + 1;

            //find the next Sunday
            int d = tA + tE;
            int m = 3;

            if (d > 31)
            {
                d -= 31;
                m++;
            }

            return new DateTime(year, m, d);
        }
    }
}