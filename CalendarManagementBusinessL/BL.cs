using CalendarManagementDataL;
using CalendarManagementModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CalendarManagementBusinessL
{
    public class BL
    {
        public DataL dataLayer = new DataL();

        public bool AddEvent(CalendarEvent newEvent)
        {
            if (dataLayer.events.Exists(e => e.EventDate.Date == newEvent.EventDate.Date))
                return false;



            dataLayer.Add(newEvent);
            return true;
        }

        public List<CalendarEvent> GetEvents()
        {
            return dataLayer.events;
        }

        public bool UpdateEvent(DateTime oldDate, string newName,  DateTime newDate)
        {
            var existing = dataLayer.events.FirstOrDefault(e => e.EventDate.Date == oldDate.Date);

            if (existing == null)
                return false;

            if (dataLayer.events.Exists(e => e.EventDate.Date == newDate.Date && e != existing))
                return false;

            existing.EventName = newName;
            existing.EventDate = newDate;

            return true;
        }

        public bool RemoveEvent(DateTime date)
        {
            return dataLayer.DeleteEvent(date);
        }
    }
}
