using System;
using CalendarManagementModels;       
using CalendarManagementBusinessL;
using System.Runtime.CompilerServices;

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
                Console.WriteLine("2. View Events");
                Console.WriteLine("3. Update Events");
                Console.WriteLine("4. Delete Events");
                Console.WriteLine("5. Exit");
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
                        Console.ReadKey();
                        break;
                    case "2":

                        Console.WriteLine("\n=== Current Events ===");

                        var events = bl.GetEvents();

                        if (events.Count == 0)
                        {
                            Console.WriteLine("No events found.");
                        }
                        else
                        {
                            foreach (var e in events)
                            {
                                Console.WriteLine($"{e.EventDate:yyyy-MM-dd} - {e.EventName}");
                            }
                        }
                        Console.ReadKey();
                        break;
                    case "3":
                        Console.WriteLine("Enter the Date of the event you want to change in this format(YYYY-MM-DD): ");
                        string oldDateInput = Console.ReadLine() ?? "";

                        DateTime oldDate;
                        if (!DateTime.TryParse(oldDateInput, out oldDate))
                        {
                            Console.WriteLine("Invalid date format!");
                            Console.ReadKey();
                            break;
                        }
                  
                        Console.Write("Enter new Event Name: ");
                        string newName = Console.ReadLine();

                        Console.Write("Enter new Event Date (YYYY-MM-DD): ");
                        string newDateInput = Console.ReadLine();

                        DateTime newDate;
                        if (!DateTime.TryParse(newDateInput, out newDate))
                        {
                            Console.WriteLine("Invalid date format!");
                            break;
                        }
                        bool updated = bl.UpdateEvent(oldDate, newName, newDate);
                        if (updated)
                            Console.WriteLine("Event Updated Sucessfully");
                        else
                            Console.WriteLine("Update Failed! Either event not found or new date conflicts with another event");

                        break;
                    case "4":
                        Console.WriteLine("Enter the Date of the Event to Delete: (YYYY-MM-DD): ");
                            string delInput = Console.ReadLine();

                            DateTime delDate;
                            if(!DateTime.TryParse(delInput, out delDate))
                            {
                                Console.WriteLine("Invalid Date format!");
                                Console.ReadKey();
                                break;
                            }

                            bool deleted = bl.RemoveEvent(delDate);
                            if (deleted)
                            {
                                Console.WriteLine("Event Deleted Successfully!");
                            }
                            else
                            {
                                Console.WriteLine("Event not found.");
                            }

                            Console.ReadKey();
                            break;

                        
                    case "5":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid option.");
                        Console.ReadKey();
                        break;
                }

            } while (running);
            Console.WriteLine("Existing Calendar Management System");
        }
    }
}