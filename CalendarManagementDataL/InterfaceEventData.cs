using System;
using System.Collections.Generic;
using CalendarManagementModels;

namespace CalendarManagementDataL
{
    public interface InterfaceEventData
    {
        void AddEvent(CalendarEvent newEvent);
        CalendarEvent? GetByDate(DateTime date);
        List<CalendarEvent> GetAllEvents();
        void UpdateEvent(DateTime oldDate, CalendarEvent updatedEvent);
        bool DeleteByDate(DateTime date);
    }
}