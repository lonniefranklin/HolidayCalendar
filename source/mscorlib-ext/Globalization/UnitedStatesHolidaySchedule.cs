/*
Copyright 2014 Lonnie Franklin

This file is part HolidayCalendar.

HolidayCalendar is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

HolidayCalendar is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with HolidayCalendar. If not, see http://www.gnu.org/licenses/.
 */
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace System.Globalization
{

    /// <summary>
    /// Specifies the Holiday Calendar type used in the United States
    /// </summary>
    [ComVisible(true)]
    [Serializable]
    public enum UnitedStatesHolidayScheduleTypes : byte
    {
        /// <summary>
        /// Indicates the Federal holiday schedule.
        /// </summary>
        Federal = 0,
        /// <summary>
        /// Indicates the Stock Market holiday schedule.
        /// </summary>
        StockMarket = 1
    }

    /// <summary>
    /// 
    /// </summary>
    public class UnitedStatesHolidaySchedule : GregorianCalendar
    {
        private readonly List<DateTime> _holidays;
        private readonly List<DateTime> _observedHolidays;

        /// <summary>
        /// Gets or sets the year.
        /// </summary>
        /// <value>
        /// The year.
        /// </value>
        public int Year { get; protected set; }

        /// <summary>
        /// Gets or sets the <see cref="T:System.Globalization.GregorianCalendarTypes"/> value that denotes the language version of the current <see cref="T:System.Globalization.GregorianCalendar"/>.
        /// </summary>
        /// <value></value>
        /// <returns>A <see cref="T:System.Globalization.GregorianCalendarTypes"/> value that denotes the language version of the current <see cref="T:System.Globalization.GregorianCalendar"/>.</returns>
        public UnitedStatesHolidayScheduleTypes UnitedStatesHolidayScheduleType { get; protected set; }
        
        protected UnitedStatesHolidaySchedule()
        {
            _holidays = new List<DateTime>();
            _observedHolidays = new List<DateTime>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitedStatesHolidaySchedule"/> class.
        /// </summary>
        /// <param name="unitedStatesHolidayScheduleType">Type of the calendar.</param>
        /// <param name="year">The year.</param>
        public UnitedStatesHolidaySchedule(UnitedStatesHolidayScheduleTypes unitedStatesHolidayScheduleType, int year) : this()
        {
            Year = year;
            UnitedStatesHolidayScheduleType = unitedStatesHolidayScheduleType;

            if (unitedStatesHolidayScheduleType == UnitedStatesHolidayScheduleTypes.StockMarket)
            {
                #region StockMarket
                /*
                U.S. stock markets are closed on nine regularly scheduled holidays each year:
                 1.  New Years Day - first of January for Monday through Saturday.
                      If it falls on Sunday, market is closed on Monday January second.
                      Every N years new years day falls on a Saturday, when this
                      happens there is NO closing of U.S stock markets for new years day.
                 2.  Dr. Martin Luther King day - third Monday in January (15-21).
                 3.  President's Day - always the third Monday in February (15-21).
                 4.  Good Friday - always on a Friday - the Friday before Easter Sunday.
                      Varies from late March to mid April.
                 5.  Memorial Day - always the last Monday in May (25-31).
                 6.  Independence Day - fourth of July for Monday through Friday.
                      If it falls on Saturday, market is closed on Friday the third.
                      If it falls on Sunday, market is closed on Monday the fifth.
                 7.  Labor Day - always on the first Monday in September (1-7).
                 8.  Thanksgiving Day - always on the fourth Thursday in November (22-28).
                 9.  Christmas Day - twenty-fifth of December for Monday through Friday.
                      If it falls on Saturday, market is closed on Friday the twenty-fourth.
                      If it falls on Sunday, market is closed on Monday the twenty-sixth.
                 */

                _holidays.Add(new DateTime(Year, 1, 1, 0, 0, 0));
                _holidays.Add(new DateTime(Year, 1, 1, 0, 0, 0).Get(WeekOfMonth.Third, DayOfWeek.Monday));
                _holidays.Add(new DateTime(Year, 2, 1, 0, 0, 0).Get(WeekOfMonth.Third, DayOfWeek.Monday));
                _holidays.Add((new GregorianCalendar()).GetGoodFriday(year));
                _holidays.Add(new DateTime(Year, 5, 1, 0, 0, 0).Get(WeekOfMonth.Last, DayOfWeek.Monday));
                _holidays.Add(new DateTime(Year, 7, 4, 0, 0, 0));
                _holidays.Add(new DateTime(Year, 9, 1, 0, 0, 0).Get(WeekOfMonth.First, DayOfWeek.Monday));
                _holidays.Add(new DateTime(Year, 11, 1, 0, 0, 0).Get(WeekOfMonth.Fourth, DayOfWeek.Thursday));
                _holidays.Add(new DateTime(Year, 12, 25, 0, 0, 0));

                foreach (var dateTime in _holidays)
                {
                    if ((dateTime.Month == 1 && dateTime.Day == 1 && dateTime.DayOfWeek == DayOfWeek.Saturday))
                        continue;

                    _observedHolidays.Add(dateTime.GetObservedDay());
                }
            #endregion
            }            
            else //Federal
            {
                #region Federal
                /*
                http://www.opm.gov/operating_status_schedules/fedhol/2012.asp
                1.  New Years Day - first of January for Monday through Saturday.
                     If it falls on Saturday, Friday is the observed
                     If it falls on Sunday, Monday is the observed
                    happens there is NO closing of U.S stock markets for new years day.
                2.  Dr. Martin Luther King day - third Monday in January (15-21).
                3.  President's Day/Washington's BDay - always the third Monday in February (15-21).
                4.  Memorial Day - always the last Monday in May (25-31).
                5.  Independence Day - fourth of July for Monday through Friday.
                     If it falls on Saturday, observed on Friday the third.
                     If it falls on Sunday, observed on Monday the fifth.
                6.  Labor Day - always on the first Monday in September (1-7).
                7.  Columbus Day - always 2nd monday of october
                8 . Veterans Day - always 11/11
                9.  Thanksgiving Day - always on the fourth Thursday in November (22-28).
                10. Christmas Day - twenty-fifth of December for Monday through Friday.
                     If it falls on Saturday, observed on Friday the twenty-fourth.
                     If it falls on Sunday, observed on Monday the twenty-sixth.
     
                */

                _holidays.Add(new DateTime(Year, 1, 1, 0, 0, 0));
                _holidays.Add(new DateTime(Year, 1, 1, 0, 0, 0).Get(WeekOfMonth.Third, DayOfWeek.Monday));
                _holidays.Add(new DateTime(Year, 2, 1, 0, 0, 0).Get(WeekOfMonth.Third, DayOfWeek.Monday));
                _holidays.Add(new DateTime(Year, 5, 1, 0, 0, 0).Get(WeekOfMonth.Last, DayOfWeek.Monday));
                _holidays.Add(new DateTime(Year, 7, 4, 0, 0, 0));
                _holidays.Add(new DateTime(Year, 9, 1, 0, 0, 0).Get(WeekOfMonth.First, DayOfWeek.Monday));
                _holidays.Add(new DateTime(Year, 10, 1, 0, 0, 0).Get(WeekOfMonth.Second, DayOfWeek.Monday));
                _holidays.Add(new DateTime(Year, 11, 11, 0, 0, 0));
                _holidays.Add(new DateTime(Year, 11, 1, 0, 0, 0).Get(WeekOfMonth.Fourth, DayOfWeek.Thursday));
                _holidays.Add(new DateTime(Year, 12, 25, 0, 0, 0));

                foreach (var dateTime in _holidays)
                    _observedHolidays.Add(dateTime.GetObservedDay());

                #endregion
            }
        }

        /// <summary>
        /// Gets or sets the holidays.
        /// </summary>
        /// <value>The holidays.</value>
        public List<DateTime> GetHolidays()
        {
            return _holidays;
        }

        /// <summary>
        /// Gets or sets the observed holidays.
        /// </summary>
        /// <value>The observed holidays.</value>
        public List<DateTime> GetObservedHolidays()
        {
            return _observedHolidays;
        }
    }
}
