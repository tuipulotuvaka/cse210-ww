using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private string _filename;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
        _filename = "goals.txt";
    }

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void DisplayGoals()
    {
        Console.WriteLine();
        Console.WriteLine("Your Goals:");

        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals have been created yet.");
        }
        else
        {
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
            }
        }

        Console.WriteLine();
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You do not have any goals yet.");
            return;
        }

        DisplayGoals();

        Console.Write("Which goal did you accomplish? ");
        int choice = int.Parse(Console.ReadLine());

        if (choice >= 1 && choice <= _goals.Count)
        {
            Goal goal = _goals[choice - 1];

            int pointsEarned = goal.RecordEvent();
            _score += pointsEarned;

            Console.WriteLine();
            Console.WriteLine($"Congratulations! You earned {pointsEarned} points.");

            DisplayLevel();

            if (goal.IsComplete())
            {
                Console.WriteLine("Goal completed!");
            }
        }
        else
        {
            Console.WriteLine("Invalid goal number.");
        }
    }

    public void DisplayScore()
    {
        Console.WriteLine($"Your score is: {_score}");
        DisplayLevel();
    }

    public void SaveGoals()
    {
        using (StreamWriter outputFile = new StreamWriter(_filename))
        {
            outputFile.WriteLine(_score);

            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved successfully.");
    }

    public void LoadGoals()
    {
        if (!File.Exists(_filename))
        {
            Console.WriteLine("No saved goals file was found.");
            return;
        }

        string[] lines = File.ReadAllLines(_filename);

        if (lines.Length == 0)
        {
            return;
        }

        _goals.Clear();

        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split('|');

            if (parts[0] == "SimpleGoal")
            {
                SimpleGoal goal = new SimpleGoal(
                    parts[1],
                    parts[2],
                    int.Parse(parts[3])
                );

                goal.SetComplete(bool.Parse(parts[4]));

                _goals.Add(goal);
            }
            else if (parts[0] == "EternalGoal")
            {
                EternalGoal goal = new EternalGoal(
                    parts[1],
                    parts[2],
                    int.Parse(parts[3])
                );

                _goals.Add(goal);
            }
            else if (parts[0] == "ChecklistGoal")
            {
                ChecklistGoal goal = new ChecklistGoal(
                    parts[1],
                    parts[2],
                    int.Parse(parts[3]),
                    int.Parse(parts[4]),
                    int.Parse(parts[5])
                );

                goal.SetAmountCompleted(int.Parse(parts[6]));

                _goals.Add(goal);
            }
        }

        Console.WriteLine("Goals loaded successfully.");
    }

    public void CreateGoal()
    {
        Console.WriteLine();
        Console.WriteLine("The types of goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.WriteLine();

        Console.Write("Which type of goal would you like to create? ");
        string choice = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        if (choice == "1")
        {
            SimpleGoal goal = new SimpleGoal(
                name,
                description,
                points
            );

            _goals.Add(goal);
        }
        else if (choice == "2")
        {
            EternalGoal goal = new EternalGoal(
                name,
                description,
                points
            );

            _goals.Add(goal);
        }
        else if (choice == "3")
        {
            Console.Write("How many times does this goal need to be completed? ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("What is the bonus for completing it? ");
            int bonus = int.Parse(Console.ReadLine());

            ChecklistGoal goal = new ChecklistGoal(
                name,
                description,
                points,
                target,
                bonus
            );

            _goals.Add(goal);
        }
        else
        {
            Console.WriteLine("Invalid goal type.");
            return;
        }

        Console.WriteLine("Goal created successfully!");
    }

    private void DisplayLevel()
    {
        int level = (_score / 500) + 1;

        Console.WriteLine($"Level: {level}");

        if (_score >= 1000)
        {
            Console.WriteLine("Quest status: Eternal Champion!");
        }
        else if (_score >= 500)
        {
            Console.WriteLine("Quest status: Rising Champion!");
        }
        else
        {
            Console.WriteLine("Quest status: Beginning the Quest!");
        }
    }
}