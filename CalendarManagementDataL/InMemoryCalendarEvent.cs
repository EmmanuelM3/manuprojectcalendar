using System;
using System.Collections.Generic;
using System.Linq;
using CalendarManagementModels;
using CalendarManagementDataL;

namespace CalendarManagementDataL
{
    public class EventInMemoryData : InterfaceEventData
    {
        private List<CalendarEvent> _events;
        public EventInMemoryData()
        {
            _events = new List<CalendarEvent>();
        }
        public void AddEvent(CalendarEvent newEvent)
        {
            _events.Add(newEvent);
        }
        public List<CalendarEvent> GetAllEvents()
        {
            return _events;
        }
        public CalendarEvent? GetByDate(DateTime date)
        {
            return _events.FirstOrDefault(e => e.EventDate.Date == date.Date);
        }
        public bool DeleteByDate(DateTime date)
        {
            var target = GetByDate(date);
            if (target != null)
            {
                _events.Remove(target);
                return true;
            }
            return false;
        }
        public void UpdateEvent(DateTime oldDate, CalendarEvent updatedEvent)
        {
            var existing = GetByDate(oldDate);
            if (existing != null)
            {

                existing.EventName = updatedEvent.EventName;
                existing.EventDate = updatedEvent.EventDate;
            }
        }
    }
}