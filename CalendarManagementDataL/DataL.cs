using System;
using System.Collections.Generic;
using CalendarManagementModels;

namespace CalendarManagementDataL
{
    public class DataL
    {

        public List<CalendarEvent> events;



        public DataL()
        {
            events = new List<CalendarEvent>();
        }

  
        public void Add(CalendarEvent calendarEvent)
        {
            events.Add(calendarEvent);
        }

     
    }
}