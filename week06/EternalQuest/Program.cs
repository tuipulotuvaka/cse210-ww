using System;

class Program
{
    static void Main(string[] args)
    {
        // Creativity:
        // Added a level-up and quest-status system based on the user's score.
        // The user earns levels every 500 points and receives special
        // status messages as their score increases.

        GoalManager manager = new GoalManager();

        bool running = true;

        while (running)
        {
            Console.Clear();

            Console.WriteLine("Eternal Quest");
            Console.WriteLine();

            manager.DisplayScore();

            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.WriteLine();

            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    manager.CreateGoal();
                    Pause();
                    break;

                case "2":
                    manager.DisplayGoals();
                    Pause();
                    break;

                case "3":
                    manager.SaveGoals();
                    Pause();
                    break;

                case "4":
                    manager.LoadGoals();
                    Pause();
                    break;

                case "5":
                    manager.RecordEvent();
                    Pause();
                    break;

                case "6":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    Pause();
                    break;
            }
        }

        Console.Clear();
        Console.WriteLine("Thank you for playing Eternal Quest!");
        manager.DisplayScore();
    }

    private static void Pause()
    {
        Console.WriteLine();
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }
}