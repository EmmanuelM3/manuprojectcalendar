using CalendarManagementDataLayer;
using CalendarManagementModels;

namespace CalendarManagementDataL
{
    public class CalendarDataService
    {
        private readonly InterfaceEventData _eventData;

        public CalendarDataService(InterfaceEventData eventData)
        {
            _eventData = eventData;
        }

        public void SaveEvent(CalendarEvent newEvent)
        {
            _eventData.AddEvent(newEvent);
        }

        public List<CalendarEvent> FetchAll()
        {
            return _eventData.GetAllEvents();
        }

        public CalendarEvent? FindByDate(DateTime date)
        {
            return _eventData.GetByDate(date);
        }

        public bool RemoveByDate(DateTime date)
        {
            return _eventData.DeleteByDate(date);
        }

        public void UpdateExisting(DateTime oldDate, CalendarEvent updatedEvent)
        {
            _eventData.UpdateEvent(oldDate, updatedEvent);
        }

        public static implicit operator CalendarDataService(CalendarDatabase v)
        {
            throw new NotImplementedException();
        }
    }
}