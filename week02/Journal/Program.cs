using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();

        List<string> prompts = new List<string>
        {
            "What was the best part of my day?",
            "What is something I learned today?",
            "Who was someone interesting I talked to today?",
            "What am I grateful for today?",
            "What is one goal I have for tomorrow?",
            "How did I see the hand of the Lord in my life today?",
            "What was something that made me smile today?"
        };

        Random random = new Random();

        int choice = 0;

        while (choice != 5)
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            string input = Console.ReadLine();

            if (int.TryParse(input, out choice))
            {
                Console.WriteLine();

                if (choice == 1)
                {
                    string prompt = prompts[random.Next(prompts.Count)];

                    Console.WriteLine(prompt);
                    Console.Write("> ");
                    string response = Console.ReadLine();

                    string date = DateTime.Now.ToShortDateString();

                    Entry entry = new Entry(date, prompt, response);

                    journal.AddEntry(entry);

                    Console.WriteLine();
                    Console.WriteLine("Entry added successfully.");
                    Console.WriteLine();
                }
                else if (choice == 2)
                {
                    journal.Display();
                }
                else if (choice == 3)
                {
                    Console.Write("What is the filename? ");
                    string filename = Console.ReadLine();

                    if (File.Exists(filename))
                    {
                        journal.LoadFromFile(filename);
                    }
                    else
                    {
                        Console.WriteLine("File not found.");
                        Console.WriteLine();
                    }
                }
                else if (choice == 4)
                {
                    Console.Write("What is the filename? ");
                    string filename = Console.ReadLine();

                    journal.SaveToFile(filename);
                }
                else if (choice == 5)
                {
                    Console.WriteLine("Thank you for using the Journal Program!");
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please choose 1-5.");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Please enter a number from 1 to 5.");
                Console.WriteLine();
            }
        }

        // Creativity / exceeding requirements:
        // This program exceeds the core requirements by displaying
        // the total number of journal entries and by providing
        // additional custom prompts beyond the required five.
    }
}