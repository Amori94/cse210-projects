class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description, int points) : base (name, description, points)
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
        _completed = true;
    }
}