class ChecklistGoal : Goal
{
    private int _bonus;
    private int _bonusPoints;
    private int _done;
    public ChecklistGoal(string name, string description, int points, int bonus, int bonusPoints) : base (name, description, points)
    {
        _bonus = bonus;
        _bonusPoints = bonusPoints;
        _done = 0;
    }

    public void addPoints()
    {
        _done += 1;
    }
    public override string GetGoal()
    {
        string goal;
        goal = $"{_name} ({_description}) - Currently completed: ({_done}/{_bonus})";
        return goal;
    }

    public override void Completed()
    {
        _completed = true;
    }

    public override string SaveGoalFormat()
    {
        string saveFormat = $"ChecklistGoal,{_name},{_description},{_points},{_bonus},{_bonusPoints},{_done},{_completed}";
        return saveFormat;
    }
}