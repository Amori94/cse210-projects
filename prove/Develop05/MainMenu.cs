class MainMenu
{
    private List<string> _mainMenu = new List<string>
    {
        "Simple Goal", "List Goals", "Save Goals", "Load Goals", "Record Event", "Quit"
    };
    private List<string> _goalMenu = new List<string>
    {
        "Create New Goal", "Eternal Goal", "Checklist Goal"
    };
    
    public MainMenu()
    {
    }

    public void DisplayMenu()
    {
        Console.Clear();
        Console.WriteLine("Menu Options:");
        int i = 1;
        foreach (string menu in _mainMenu)
        {
            Console.WriteLine($"    {i}. {menu}");
            i++;
        }
    }

    public void DisplayGoalMenu()
    {
        Console.Clear();
        Console.WriteLine("Goals Menu:");
        int i = 1;
        foreach (string menu in _goalMenu)
        {
            Console.WriteLine($"    {i}. {menu}");
            i++;
        }
    }
}