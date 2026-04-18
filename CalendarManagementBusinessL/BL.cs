using CalendarManagementDataL;
using CalendarManagementDataLayer;
using CalendarManagementModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CalendarManagementBusinessL
{
    public class BL
    {
        private readonly CalendarDataService _eventService;

        public BL()
        {
            _eventService = new CalendarDataService(new CalendarDatabase());
        }

        public bool AddEvent(CalendarEvent newEvent)
        {
            if (_eventService.FindByDate(newEvent.EventDate) != null)
            {
                return false;
            }

            _eventService.SaveEvent(newEvent);
            return true;
        }

        public List<CalendarEvent> GetEvents()
        {
            return _eventService.FetchAll();
        }

        public bool UpdateEvent(DateTime oldDate, string newName, DateTime newDate)
        {
            var existing = _eventService.FindByDate(oldDate);
            if (existing == null) return false;

            if (oldDate.Date != newDate.Date)
            {
                var conflict = _eventService.FindByDate(newDate);
                if (conflict != null)
                {
                    return false;
                }
            }

            existing.EventName = newName;
            existing.EventDate = newDate;

            _eventService.UpdateExisting(oldDate, existing);
            return true;
        }

        public bool RemoveEvent(DateTime date)
        {
            return _eventService.RemoveByDate(date);
        }
    }
}
