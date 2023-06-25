class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) : base (name, description, points)
    {   
    }

    public override string GetGoal()
    {
        string goal;
        goal = $"{_name} ({_description})";
        return goal;
    }

    public override void Completed()
    {
    }

    public override string SaveGoalFormat()
    {
        string saveFormat = $"EternalGoal,{_name},{_description},{_points}";
        return saveFormat;
    }

    public override void AddPoints()
    {}
    public override int GetBonus()
    {
        return 0;
    }
}