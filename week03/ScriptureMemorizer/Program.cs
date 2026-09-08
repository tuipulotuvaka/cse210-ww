using System;

class Program
{
    static void Main(string[] args)
    {
        // Creativity: Instead of using only one scripture, this program
        // contains a small library of scriptures and randomly selects one.
        Random random = new Random();

        int choice = random.Next(3);

        Scripture scripture;

        if (choice == 0)
        {
            Reference reference = new Reference("Proverbs", 3, 5, 6);

            scripture = new Scripture(
                reference,
                "Trust in the Lord with all thine heart; and lean not unto thine own understanding. " +
                "In all thy ways acknowledge him, and he shall direct thy paths."
            );
        }
        else if (choice == 1)
        {
            Reference reference = new Reference("John", 3, 16);

            scripture = new Scripture(
                reference,
                "For God so loved the world, that he gave his only begotten Son, " +
                "that whosoever believeth in him should not perish, but have everlasting life."
            );
        }
        else
        {
            Reference reference = new Reference("Philippians", 4, 13);

            scripture = new Scripture(
                reference,
                "I can do all things through Christ which strengtheneth me."
            );
        }

        while (!scripture.AllWordsHidden())
        {
            Console.Clear();

            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.Write("Press Enter to hide words or type 'quit' to exit: ");

            string input = Console.ReadLine();

            if (input != null && input.Trim().ToLower() == "quit")
            {
                return;
            }

            scripture.HideRandomWords(3);
        }

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
    }
}