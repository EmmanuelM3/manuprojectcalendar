using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using CalendarManagementModels;

namespace CalendarManagementDataL
{

    public class CalendarEventJson : InterfaceEventData
    {
        private List<CalendarEvent> _events = new List<CalendarEvent>();
        private readonly string _jsonFileName;

        public CalendarEventJson()
        {
            _jsonFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Event.json");
            PopulateJsonFile();
        }

        private void PopulateJsonFile()
        {
            if (File.Exists(_jsonFileName)) RetrieveDataFromJsonFile();
            else SaveDataToJsonFile();
        }

        private void SaveDataToJsonFile()
        {
            using var outputStream = File.Create(_jsonFileName);
            JsonSerializer.Serialize(outputStream, _events, new JsonSerializerOptions { WriteIndented = true });
        }

        private void RetrieveDataFromJsonFile()
        {
            try
            {
                string jsonString = File.ReadAllText(_jsonFileName);
                _events = JsonSerializer.Deserialize<List<CalendarEvent>>(jsonString,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<CalendarEvent>();
            }
            catch { _events = new List<CalendarEvent>(); }
        }

        public void AddEvent(CalendarEvent newEvent) { _events.Add(newEvent); SaveDataToJsonFile(); }
        public List<CalendarEvent> GetAllEvents() { RetrieveDataFromJsonFile(); return _events; }
        public CalendarEvent? GetByDate(DateTime date)
        {
            RetrieveDataFromJsonFile();
            return _events.FirstOrDefault(e => e.EventDate.Date == date.Date);
        }
        public bool DeleteByDate(DateTime date)
        {
            RetrieveDataFromJsonFile();
            var target = GetByDate(date);
            if (target != null) { _events.Remove(target); SaveDataToJsonFile(); return true; }
            return false;
        }
        public void UpdateEvent(DateTime oldDate, CalendarEvent updatedEvent)
        {
            RetrieveDataFromJsonFile();
            var existing = GetByDate(oldDate);
            if (existing != null)
            {
                existing.EventName = updatedEvent.EventName;
                existing.EventDate = updatedEvent.EventDate;
                SaveDataToJsonFile();
            }
        }
    }
}