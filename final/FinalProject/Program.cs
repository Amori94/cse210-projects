using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string input = "";
        bool loaded = false;
        Console.WriteLine("                 ___          ____    \n"+
        "|\\    /|   /\\   |   |\\      /|    |   \n"+
        "| \\  / |  /  \\  |___| \\    / |___ |   \n"+
        "|  \\/  | /____\\ |  \\   \\  /  |    |   \n"+
        "|      |/      \\|   \\   \\/   |____|___");
        Console.WriteLine("       _    _      _   _      _ \n"+
        "      | |_||_||\\/||_||| ||\\ ||_ \n"+
        "      |_| || ||  ||  ||_|| \\| _|");
        SlowWrite("      ---------COMPANION--------      ");
        Console.Write("\n\nPress Enter key to continue...");
        Console.ReadLine();

        while (input != "Quit")
        {
            input = MainMenu(loaded);

            if (input == "New Game")
            {
                InitiateNewGame();
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

    static string MainMenu(bool loaded)
    {
        //initiate mainMenu List and int i, set title for menu
        string title = "Main Menu";
        List<string> mainMenu = new List<string>
        {"New Game", "Load Game", "Quit"};
        //if loaded game, continue instead of new game
        if (loaded == true) {mainMenu[0] = "Continue Game";}

        Menus menu = new Menus(title, mainMenu);

        return menu.SimpleMenu();
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

        Menus menu = new Menus(path, fileNames);

        return menu.SimpleMenu();
    }

    static void GameLoader(string fileName)
    {
        Console.Clear();
        Console.Write($"{fileName} has been loaded correctly.\n Press Enter to continue... ");
        Console.ReadLine();
    }

    static void InitiateNewGame()
    {
        //initiate int variable heroCount
        int heroCount;

        //select scenario and module
        ScenarioSelector();

        //select heroes
        Console.Write("How many players will play?(1-4) ");
        heroCount = Int32.Parse(Console.ReadLine());
        HeroSelector(heroCount);
    }

    static void HeroSelector(int heroCount)
    {
        List<Hero> heroes = new List<Hero>();
        List<string> chooseHeroes = new List<string>();
        string fileName = "Game Objects/Heroes.txt";

        foreach (string line in System.IO.File.ReadAllLines(fileName).ToList())
        {
            chooseHeroes.Add($"{line.Split(", ").ToList()[0]}");
        }

        while (heroCount != 0)
        {
            Menus heroList = new Menus("Choose your hero", chooseHeroes);
            string chosenHero = heroList.SimpleMenu();
            Console.WriteLine($"You have chosen {chosenHero}!");
            Console.Write("Press Enter key to continue... ");
            Console.ReadLine();
            chooseHeroes.Remove(chosenHero);
            heroCount--;
        }
    }

    static void HeroTurn(Hero name, int rep)
    {
        List<string> turnMenu = new List<string>
        {"Check Turn Options", "Change HP", "Change Identity", "End Turn"};

        Console.Clear();
        Console.Write($"It is {name.GetName()}'s turn, get ready ");
        Countdown(3);
        
        Menus menu = new Menus($"It is {name.GetName()}'s turn", turnMenu);
        menu.displayMenu();
    }

    static void VillainTurn(Villain name, int rep)
    {
        List<string> turnMenu = new List<string>
        {"Check Turn Options", "Change HP", "End Turn"};
        Menus menu = new Menus($"It is {name.GetName()}'s turn", turnMenu);
        menu.displayMenu();
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
        Menus menu = new Menus("-Scenarios-", scenarios);
        chosen = menu.SimpleMenu();

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

    static void SlowWrite(string phrase)
    {
        Console.CursorVisible = false;

        foreach (Char letter in phrase)
        {
                Thread.Sleep(125);
                Console.Write(letter);
        }

        Console.CursorVisible = true;
    }
}