using System;

namespace manucalendar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] eventNames = new string[100];
            DateTime[] startTimes = new DateTime[100];
            DateTime[] endTimes = new DateTime[100];
            int eventCount = 0;

            string choice = "";

            do
            {
                Console.WriteLine("\nCALENDAR MENU");
                Console.WriteLine("1. Add Event");
                Console.WriteLine("2. View Events");
                Console.WriteLine("3. Exit");
                Console.Write("Choose: ");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddEvent();
                        break;

                    case "2":
                        ViewEvents();
                        break;

                    case "3":
                        Console.WriteLine("Exiting...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            } while (choice != "3");

       
            void AddEvent()
            {
                if (eventCount >= 100)
                {
                    Console.WriteLine("Event list is full.");
                    return;
                }

                Console.Write("Event Name: ");
                string name = Console.ReadLine();

                Console.Write("Start Time (yyyy-MM-dd HH:mm): ");
                if (!DateTime.TryParse(Console.ReadLine(), out DateTime start))
                {
                    Console.WriteLine("Invalid date format.");
                    return;
                }

                Console.Write("End Time (yyyy-MM-dd HH:mm): ");
                if (!DateTime.TryParse(Console.ReadLine(), out DateTime end))
                {
                    Console.WriteLine("Invalid date format.");
                    return;
                }

                if (end <= start)
                {
                    Console.WriteLine("Invalid time. End must be after start.");
                    return;
                }

            
              
                }
            }
        }
    }
