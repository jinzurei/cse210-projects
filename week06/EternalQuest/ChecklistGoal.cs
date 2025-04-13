using System;

public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus)
        : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = 0;
    }

    public override int RecordEvent()
    {
        _amountCompleted++;

        if (_amountCompleted == _target)
        {
            int totalPoints = _points + _bonus;
            Console.WriteLine($"Congrats! You completed the checklist goal and earned {_points} + bonus {_bonus} = {totalPoints} points!");
            return totalPoints;
        }
        else if (_amountCompleted < _target)
        {
            Console.WriteLine($"Good job! You earned {_points} points. Progress: {_amountCompleted}/{_target}");
            return _points;
        }
        else
        {
            Console.WriteLine($"You already completed this goal, though we will still award {_points} for extra effort!");
            return _points;
        }
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override string GetDetailsString()
    {
        string checkmark = IsComplete() ? "[X]" : "[ ]";
        return $"{checkmark} {_shortName} ({_description}) -- Completed {_amountCompleted}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal|{_shortName}|{_description}|{_points}|{_bonus}|{_target}|{_amountCompleted}";
    }
}