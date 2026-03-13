using CalendarManagementDataL;
using CalendarManagementModels;
using System;
using System.Collections.Generic;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;



namespace CalendarManagementBusinessL
{
    public class BL
    {
        public DataL dataLayer = new DataL();

        public bool AddEvent(CalendarEvent newEvent)
        {
            if (dataLayer.dummyEvents.Exists(e => e.EventDate.Date == newEvent.EventDate.Date))
                return false;

            dataLayer.Add(newEvent);
            return true;
        }
    }
}