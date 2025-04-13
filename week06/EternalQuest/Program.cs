// Added a leveling and title system to make progress more rewarding.
// Players earn titles like "Adventurer" as their score increases.

using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}