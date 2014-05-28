/*
Copyright 2014 Lonnie Franklin

This file is part HolidayCalendar.

HolidayCalendar is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

HolidayCalendar is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with HolidayCalendar. If not, see http://www.gnu.org/licenses/.
 */
using System.Runtime.InteropServices;

namespace System
{
    /// <summary>
    /// Specifies the month of the year
    /// </summary>
    [ComVisible(true)]
    [Serializable]
    public enum MonthOfYear
    {
        /// <summary>
        /// Indiciates January
        /// </summary>
        January,
        /// <summary>
        /// Indiciates February
        /// </summary>
        February,
        /// <summary>
        /// Indiciates March
        /// </summary>
        March,
        /// <summary>
        /// Indiciates April
        /// </summary>
        April,
        /// <summary>
        /// Indiciates May
        /// </summary>
        May,
        /// <summary>
        /// Indiciates June
        /// </summary>
        June,
        /// <summary>
        /// Indiciates July
        /// </summary>
        July,
        /// <summary>
        /// Indiciates August
        /// </summary>
        August,
        /// <summary>
        /// Indiciates September
        /// </summary>
        September,
        /// <summary>
        /// Indiciates October
        /// </summary>
        October,
        /// <summary>
        /// Indiciates November
        /// </summary>
        November,
        /// <summary>
        /// Indiciates December
        /// </summary>
        December
    }


    /// <summary>
    /// Specifies the week of the month
    /// </summary>
    [ComVisible(true)]
    [Serializable]
    public enum WeekOfMonth : byte
    {
        /// <summary>
        /// Indiciates the first week of the month
        /// </summary>
        First = 0,
        /// <summary>
        /// Indiciates the second week of the month
        /// </summary>
        Second = 1,
        /// <summary>
        /// Indiciates the third week of the month
        /// </summary>
        Third = 2,
        /// <summary>
        /// Indiciates the fourth week of the month
        /// </summary>
        Fourth = 3,
        /// <summary>
        /// Indiciates the fifth, if applicable else the fourth, week of the month
        /// </summary>
        Last = 4
    }
}