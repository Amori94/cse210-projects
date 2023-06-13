class MainMenu
{
    private List<string> _menu = new List<string>();
    private string _breath = "breathing";
    private string _reflect = "reflecting";
    private string _list = "listing";
    private string _userChoice;

    public MainMenu()
    {
        _menu.Add(_breath);
        _menu.Add(_reflect);
        _menu.Add(_list);
    }

    public void ShowMenu()
    {
        int i = 1;

        Console.Clear();
        Console.WriteLine("Menu Options:");

        foreach (string act in _menu)
        {
            Console.WriteLine($"    {i} - Start {act} activity");
            i++;
        }

        Console.WriteLine($"    {i} - Quit");
        Console.Write($"Select a choice from the menu: ");
        _userChoice = Console.ReadLine();
        ChooseActivity(_userChoice);
    }

    public void ChooseActivity(string userChoice)
    {
        if(userChoice == "1")
        {
            BreathingActivity startAct = new BreathingActivity();
            startAct.DisplayStartMsg();
            startAct.BreathSeq();
            startAct.DisplayEndMsg();
        }
        else if(userChoice == "2")
        {
            ReflectingActivity startAct = new ReflectingActivity();
            startAct.DisplayStartMsg();
        }
        else if(userChoice == "3")
        {
            ListingActivity startAct = new ListingActivity();
            startAct.DisplayStartMsg();
        }
        else if(userChoice == "4")
        {
            Environment.Exit(0);
        }
    }
}