using System;
using CalendarManagementModels;       
using CalendarManagementBusinessL;    

namespace CalendarManagementUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BL bl = new BL();

            Console.WriteLine("=== Calendar Management: Add Event ===");

            Console.Write("Enter Event Name: ");
            string name = Console.ReadLine() ?? "";

            Console.Write("Enter Event Date (YYYY-MM-DD): ");
            string inputDate = Console.ReadLine() ?? "";

            DateTime eventDate;
            if (!DateTime.TryParse(inputDate, out eventDate))
            {
                Console.WriteLine("Invalid date format!");
                return;
            }

            CalendarEvent newEvent = new CalendarEvent
            {
                EventId = Guid.NewGuid(),
                EventName = name,
                EventDate = eventDate
            };

            bool added = bl.AddEvent(newEvent);

            if (added)
            {
                Console.WriteLine("Event added successfully!");
            }
            else
            {
                Console.WriteLine("Date already has an event! Cannot add.");
            }

            Console.WriteLine("\n=== Current Events ===");
            foreach (var e in bl.dataLayer.dummyEvents)
            {
                Console.WriteLine($"{e.EventDate:yyyy-MM-dd} - {e.EventName}");
            }
        }
    }
}