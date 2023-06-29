using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string input = "";
        bool loaded = false;
        Console.WriteLine("MARVEL CHAMPIONS COMPANION");
        Console.Write("Starting in... ");
        Countdown(3);

        while (input != "Quit")
        {
            input = DisplayMainMenu(loaded);

            if (input == "New Game")
            {
                ScenarioSelector();
            }

            else if (input == "Continue Game")
            {

            }

            else if (input == "Load Game")
            {
                GameLoader(LoadGame());
                loaded = true;
            }
        }
    }

    static string DisplayMainMenu(bool loaded)
    {
        //initiate mainMenu List and int i
        List<string> mainMenu = new List<string>
        {"New Game", "Load Game", "Quit"};
        if (loaded == true) {mainMenu[0] = "Continue Game";}

        return MenuReader("Main Menu", mainMenu);
    }

    static string LoadGame()
    {   
        //get file names into List
        string path = "Saved Files";
        string[] savedGames = Directory.GetFiles(path);
        List<string> fileNames = new List<string>();
        
        foreach(string name in savedGames)
        {
            fileNames.Add(Path.GetFileName(name));
        }

        return MenuReader("Saved Games", fileNames);
    }

    static void GameLoader(string fileName)
    {
        Console.Clear();
        Console.Write($"{fileName} has been loaded correctly.\n Press Enter to continue... ");
        Console.ReadLine();
    }

    static void HeroTurn(Hero name, int rep)
    {
        List<string> turnMenu = new List<string>
        {"Check Turn Options", "Change HP", "Change Identity", "End Turn"};

        Console.Clear();
        Console.Write($"It is {name.GetName()}'s turn, get ready in ");
        Countdown(5);
        
        MenuReader("Hero Turn", turnMenu);
    }

    static void VillainTurn(Villain name, int rep)
    {
        List<string> turnMenu = new List<string>
        {"Check Turn Options", "Change HP", "End Turn"};
        MenuReader("Hero Turn", turnMenu);
    }

    static void ScenarioSelector()
    {
        List<string> scenarios = new List<string>();
        string fileName = "Game Objects/Scenarios.txt";
        string chosen;
        string module = "";
        int threat = 0;
        int startThreat = 0;
        int roundThreat = 0;
        
        foreach (string line in System.IO.File.ReadAllLines(fileName).ToList())
        {
            scenarios.Add($"{line.Split(", ").ToList()[0]}");
        }

        chosen = MenuReader("Scenarios", scenarios);

        foreach (string line in System.IO.File.ReadAllLines(fileName).ToList())
        {
            if ((line.Split(", ").ToList()[0]) == chosen)
            {
                module = line.Split(", ").ToList()[1];
                threat = Int32.Parse(line.Split(", ").ToList()[3]);
                startThreat = Int32.Parse(line.Split(", ").ToList()[4]);
                roundThreat = Int32.Parse(line.Split(", ").ToList()[5]);
            }
        }       

        Console.WriteLine($"You have chosen to {chosen}");
        Scenario newScene = new Scenario(chosen, module, threat, startThreat, roundThreat);
    }

    static string MenuReader(string title, List<string> menu)
    {
        int input;
        int i = 1;

        Console.Clear();
        Console.WriteLine($"{title}:");

        foreach (string name in menu)
        {
            Console.WriteLine($"    {i}. {name}");
            i++;
        }

        //get user input to choose menu option
        Console.Write("Choose an option: ");
        input = Int32.Parse(Console.ReadLine());

        return menu[input - 1];
    }

    static void Countdown(int start)
    {
        Console.CursorVisible = false;

        while (start != 0)
        {
                Console.Write(start);
                Thread.Sleep(1000);
                Console.Write("\b \b");
                start--;
        }

        Console.CursorVisible = true;
    }
}