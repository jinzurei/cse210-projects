using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private int _level;
    private string _title;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
        _level = 1;
        _title = "Beginner";
    }

    private void UpdateLevel()
    {
        _level = (_score / 1000) + 1;

        if (_score >= 5000)
            _title = "Legendary Hero";
        else if (_score >= 3000)
            _title = "Quest Master";
        else if (_score >= 2000)
            _title = "Champion";
        else if (_score >= 1000)
            _title = "Adventurer";
        else
            _title = "Beginner";
    }

    public void Start()
    {
        string input = "";

        while (input != "7")
        {
            Console.WriteLine($"\nYou have {_score} points.");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Display Player Info");
            Console.WriteLine("  7. Quit");
            Console.Write("Select a choice from the menu: ");
            input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    DisplayPlayerInfo();
                    break;
                case "7":
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid input. Try again.");
                    break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"\nCurrent Score: {_score} points");
        Console.WriteLine($"Level: {_level}");
        Console.WriteLine($"Title: {_title}");
    }

    public void CreateGoal()
    {
        Console.WriteLine("\nThe types of goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string typeInput = Console.ReadLine();

        Console.Write("Enter the name of your goal: ");
        string name = Console.ReadLine();

        Console.Write("Enter a short description: ");
        string description = Console.ReadLine();

        Console.Write("Enter the points associated with this goal: ");
        int points = int.Parse(Console.ReadLine());

        Goal newGoal = null;

        if (typeInput == "1")
        {
            newGoal = new SimpleGoal(name, description, points);
        }
        else if (typeInput == "2")
        {
            newGoal = new EternalGoal(name, description, points);
        }
        else if (typeInput == "3")
        {
            Console.Write("Enter the number of times this goal must be accomplished: ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("Enter the bonus points for completing it: ");
            int bonus = int.Parse(Console.ReadLine());

            newGoal = new ChecklistGoal(name, description, points, target, bonus);
        }
        else
        {
            Console.WriteLine("Invalid selection. Returning to menu.");
            return;
        }

        _goals.Add(newGoal);
        Console.WriteLine("Goal created successfully!");
    }

    public void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("\nNo goals have been created yet.");
            return;
        }

        Console.WriteLine("\nYour Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Goal goal = _goals[i];
            string details = goal.GetDetailsString();
            Console.WriteLine($"  {i + 1}. {details}");
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("\nNo goals to record. Create one first.");
            return;
        }

        Console.WriteLine("\nWhich goal did you accomplish?");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {_goals[i].GetDetailsString()}");
        }

        Console.Write("Enter the number of the goal: ");
        string input = Console.ReadLine();
        int index;

        if (int.TryParse(input, out index) && index >= 1 && index <= _goals.Count)
        {
            Goal selectedGoal = _goals[index - 1];
            int pointsEarned = selectedGoal.RecordEvent();
            _score += pointsEarned;
            UpdateLevel();
            Console.WriteLine($"Total Score: {_score} points | Level: {_level} - Title: {_title}");
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }
    }

    public void SaveGoals()
    {
        Console.Write("Enter the filename to save goals: ");
        string fileName = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            outputFile.WriteLine(_score); // Save score first
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved successfully.");
    }

    public void LoadGoals()
    {
        Console.Write("Enter the filename to load goals: ");
        string fileName = Console.ReadLine();

        if (!File.Exists(fileName))
        {
            Console.WriteLine("File not found.");
            return;
        }

        string[] lines = File.ReadAllLines(fileName);
        _score = int.Parse(lines[0]);
        _goals.Clear();

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split('|');
            string goalType = parts[0];

            if (goalType == "SimpleGoal")
            {
                string name = parts[1];
                string desc = parts[2];
                int points = int.Parse(parts[3]);
                bool isComplete = bool.Parse(parts[4]);

                SimpleGoal g = new SimpleGoal(name, desc, points);
                g.SetComplete(isComplete); //  Added to set the internal flag without adding points
                _goals.Add(g);
            }

            else if (goalType == "EternalGoal")
            {
                string name = parts[1];
                string desc = parts[2];
                int points = int.Parse(parts[3]);

                _goals.Add(new EternalGoal(name, desc, points));
            }
            else if (goalType == "ChecklistGoal")
            {
                string name = parts[1];
                string desc = parts[2];
                int points = int.Parse(parts[3]);
                int bonus = int.Parse(parts[4]);
                int target = int.Parse(parts[5]);
                int completed = int.Parse(parts[6]);

                ChecklistGoal g = new ChecklistGoal(name, desc, points, target, bonus);

                // Simulate completions
                for (int c = 0; c < completed; c++)
                {
                    g.RecordEvent();
                }

                _goals.Add(g);
            }
        }

        Console.WriteLine("Goals loaded successfully.");
    }

}