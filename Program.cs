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
            bool running = true;

            do
            {
                Console.WriteLine("\n Calendar Management System ");
                Console.WriteLine("1. Add Event");
                Console.WriteLine("2. Exit");
                string choice = Console.ReadLine(); 

                switch(choice) {
                    case "1":
                        Console.Write("Enter Event Name: ");
                        string name = Console.ReadLine() ?? "";

                        Console.Write("Enter Event Date (YYYY-MM-DD): ");
                        string inputDate = Console.ReadLine() ?? "";

                        DateTime eventDate;
                        if (!DateTime.TryParse(inputDate, out eventDate))
                        {
                            Console.WriteLine("Invalid date format!");
                            break;
                        }

                        CalendarEvent newEvent = new CalendarEvent
                        {
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
                        foreach (var e in bl.dataLayer.events)
                        {
                            Console.WriteLine($"{e.EventDate:yyyy-MM-dd} - {e.EventName}");
                        }

                        break;

                    case "2":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }

            } while (running);
        }
    }
}