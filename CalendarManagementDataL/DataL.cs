using System;
using System.Collections.Generic;
using CalendarManagementModels;

namespace CalendarManagementDataL
{
    public class DataL
    {
        
        public List<CalendarEvent> dummyEvents = new List<CalendarEvent>();


        public DataL()
        {
            CalendarEvent birthday = new CalendarEvent
            {
               
            };

            dummyEvents.Add(birthday);
        }

  
        public void Add(CalendarEvent calendarEvent)
        {
            dummyEvents.Add(calendarEvent);
        }
    }
}