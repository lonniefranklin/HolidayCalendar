HolidayCalendar
===============

Helpful US holiday class and DateTime extensions

#How to use

//federal holidays

var holidaySchedule = new UnitedStatesHolidaySchedule(UnitedStatesHolidayScheduleTypes.Federal, DateTime.Today.Year);

//federal observed holidays

var observed = holidaySchedule.GetObservedHolidays()



//stockmarket holidays

var smHolidaySchedule = new UnitedStatesHolidaySchedule(UnitedStatesHolidayScheduleTypes.StockMarket, DateTime.Today.Year);

//federal observed holidays

var smObserved = smHolidaySchedule.GetObservedHolidays()
