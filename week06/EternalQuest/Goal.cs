using System;

public abstract class Goal
{
    protected string _shortName;
    protected string _description;
    protected int _points;

    public Goal(string shortName, string description, int points)
    {
        _shortName = shortName;
        _description = description;
        _points = points;
    }

    // Abstract methods - must be overridden by subclasses
    public abstract int RecordEvent(); // ← was void
    public abstract bool IsComplete();
    public abstract string GetStringRepresentation();

    // Virtual method - can be overridden, but has a default version
    public virtual string GetDetailsString()
    {
        string checkmark = IsComplete() ? "[X]" : "[ ]";
        return $"{checkmark} {_shortName} ({_description})";
    }

    public int GetPoints()
    {
        return _points;
    }
}