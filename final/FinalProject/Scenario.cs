class Scenario
{
    string _name;
    string _difficulty;
    string _modules;
    int _threat;
    int _startThreat;
    int _roundThreat;

    public Scenario(string name, string modules, int threat, int startThreat, int roundThreat)
    {
        _name = name;
        _difficulty = "Standard";
        _modules = modules;
        _threat = threat;
        _startThreat = startThreat;
        _roundThreat = roundThreat;
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
}