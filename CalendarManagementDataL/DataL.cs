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

        public bool DeleteEvent(DateTime date)
        {
            var existing = events.FirstOrDefault(e => e.EventDate.Date == date.Date);
            if (existing != null)
            {
                events.Remove(existing);
                return true;
            }
            return false;
        }
     
    }
}