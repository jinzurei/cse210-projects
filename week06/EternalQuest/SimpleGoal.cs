using System;

public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points) : base(name, description, points)
    {
        _isComplete = false;
    }

    public override int RecordEvent()
    {
        if (!_isComplete)
        {
            Console.WriteLine($"Congratulations! You earned {_points} points.");
            _isComplete = true;
            return _points;
        }
        else
        {
            Console.WriteLine("This goal is already completed.");
            return 0;
        }
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal|{_shortName}|{_description}|{_points}|{_isComplete}";
    }

    public void SetComplete(bool isComplete)
    {
        _isComplete = isComplete;
    }
}