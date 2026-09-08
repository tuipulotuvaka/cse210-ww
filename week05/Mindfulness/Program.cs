using System;

class Program
{
    static void Main(string[] args)
    {
        // Creativity feature:
        // This program keeps a session count of how many mindfulness
        // activities the user completes during the current run.

        int completedActivities = 0;
        bool running = true;

        while (running)
        {
            Console.Clear();

            Console.WriteLine("Mindfulness Program");
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.WriteLine();

            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    BreathingActivity breathing = new BreathingActivity();
                    breathing.Run();
                    completedActivities++;
                    break;

                case "2":
                    ReflectionActivity reflection = new ReflectionActivity();
                    reflection.Run();
                    completedActivities++;
                    break;

                case "3":
                    ListingActivity listing = new ListingActivity();
                    listing.Run();
                    completedActivities++;
                    break;

                case "4":
                    running = false;
                    break;

                default:
                    Console.WriteLine();
                    Console.WriteLine("Invalid choice. Please select 1, 2, 3, or 4.");
                    System.Threading.Thread.Sleep(1500);
                    break;
            }
        }

        Console.Clear();
        Console.WriteLine("Thank you for using the Mindfulness Program.");
        Console.WriteLine($"Activities completed this session: {completedActivities}");
    }
}