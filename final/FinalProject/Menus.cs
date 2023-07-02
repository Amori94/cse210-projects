class Menus
{
    string _title;
    string _menuString;
    List<string> _menu;
    public Menus(string title, List<string> menu) 
    {
        _title = title;
        _menu = menu;
    }

    public Menus(string title, List<string> menu, string menuString) 
    {
        _title = title;
        _menu = menu;
        _menuString = menuString;
    }

    public string SimpleMenu()
    {
        //initiate variables
        int input;
        int i = 1;

        //clear console and show title
        Console.Clear();
        Console.WriteLine($"{_title}:");

        //loop through menu list for display
        foreach (string name in _menu)
        {
            Console.WriteLine($"    {i}. {name}");
            i++;
        }

        //get user input to choose menu option
        Console.Write("Choose an option: ");
        input = Int32.Parse(Console.ReadLine());

        return _menu[input - 1];
    }

    public string PersonalizedMenu()
    {
        //initiate variables
        int input;
        int i = 1;

        //clear console and show title
        Console.Clear();
        Console.WriteLine($"{_title}:");

        //loop through menu list for display
        foreach (string name in _menu)
        {
            Console.WriteLine($"    {i}. {_menuString}{name}");
            i++;
        }

        //get user input to choose menu option
        Console.Write("Choose an option: ");
        input = Int32.Parse(Console.ReadLine());

        return _menu[input - 1];
    }

    public void displayMenu()
    {
        //initiate variables
        int i = 1;

        //clear console and show title
        Console.Clear();
        Console.WriteLine($"{_title}:");

        //loop through menu list for display
        foreach (string name in _menu)
        {
            Console.WriteLine($"    {i}. {_menuString}{name}");
            i++;
        }

        //get user input to continue
        Console.Write("Press Enter key to continue");
        Console.ReadLine();
    }
}