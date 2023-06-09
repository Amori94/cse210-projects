public abstract class Goal
{
    protected string _name;
    protected string _description;
    protected int _points;
    protected bool _completed;

    public Goal (string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
        _completed = false;
    }

    public abstract string GetGoal();
    public abstract void Completed();
    public abstract void AddPoints();
    public abstract int GetBonus();
    public abstract string SaveGoalFormat();
    public string GetName()
    {
        return _name;
    }
    public int GetPoints()
    {
        return _points;
    }
    public virtual string CheckCompleted()
    {
        string checkMark = " ";

        if (_completed == true)
        {
            checkMark = "X";
        }

        return checkMark;
    }
}