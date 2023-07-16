class Scenario
{
    string _name;
    string _villain;
    string _difficulty;
    string _modules;
    int _threat;
    int _startThreat;
    int _roundThreat;
    int _currentThreat;

    public Scenario(string name, string villain, string modules, int threat, int startThreat, int roundThreat)
    {
        _name = name;
        _villain = villain;
        _difficulty = "Standard";
        _modules = modules;
        _threat = threat;
        _startThreat = startThreat;
        _roundThreat = roundThreat;
        _currentThreat = startThreat;
    }

    public void ChangeDifficulty()
    {
        _difficulty = "Expert";
    }

    public string GetName()
    {
        return _name;
    }

    public string GetDifficulty()
    {
        return _difficulty;
    }

    public string GetVillain()
    {
        return _villain;
    }

    public int GetThreat()
    {
        return _currentThreat;
    }

    public int GetEndThreat()
    {
        return _threat;
    }

    public int GetRoundThreat()
    {
        return _roundThreat;
    }

    public void Interrupt(int points)
    {
        _currentThreat = _currentThreat - points;
    }

    public void Plan(int points)
    {
        _currentThreat = _currentThreat + points;
    }

    public string ExportData()
    {
        string data = "";
        data = $"{_name},{_villain},{_difficulty},{_modules},{_threat},{_startThreat},{_roundThreat},{_currentThreat}";
        return data;
    }
}