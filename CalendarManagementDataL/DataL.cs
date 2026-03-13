using System;
using System.Collections.Generic;
using CalendarManagementModels;

namespace CalendarManagementDataL
{
    public class DataL
    {
        // List to store events
        public List<CalendarEvent> dummyEvents = new List<CalendarEvent>();

        // Constructor with 1 dummy event
        public DataL()
        {
            CalendarEvent birthday = new CalendarEvent
            {
               
            };

            dummyEvents.Add(birthday);
        }

        // Add new event
        public void Add(CalendarEvent calendarEvent)
        {
            dummyEvents.Add(calendarEvent);
        }
    }
}