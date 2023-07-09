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
        Scenario scenario = ScenarioSelector();

        //initiate villain
        Villain villain = VillainSelector(scenario.GetVillain());

        //select heroes
        Console.Write("How many players will play?(1-4) ");
        heroCount = Int32.Parse(Console.ReadLine());
        List<Hero> heroes = HeroSelector(heroCount);

        //set initial stats
        Console.WriteLine($"You are playing {scenario.GetDifficulty()} {scenario.GetName()}");
        Console.WriteLine("The heroes are: ");
        foreach (Hero hero in heroes)
        {
            Console.WriteLine($"{hero.GetName()} - current HP = {hero.GetHP()}");
        }

        Console.WriteLine("Press Enter key to continue..."); Console.ReadLine();

        HeroTurn(heroes, villain);
    }

    static void Game(Scenario scenario, List<Hero> heroes, Villain villain)
    {
        CheckDeath(heroes);

        if (!heroes.Any())
        {
            
        }
    }

    static List<Hero> HeroSelector(int heroCount)
    {
        //initiate List<Hero> to store loaded heroes
        List<Hero> heroes = new List<Hero>();
        //initiate List<string> to store hero names for selection menu
        List<string> chooseHeroes = new List<string>();
        //initiate string with file path
        string path = "Game Objects/Heroes.txt";

        //create list with hero names from file
        foreach (string line in System.IO.File.ReadAllLines(path).ToList())
        {
            chooseHeroes.Add($"{line.Split(", ").ToList()[0]}");
        }

        //loop until player count is satisfied
        while (heroCount != 0)
        {
            //User picks hero from hero list created from file
            Menus heroList = new Menus("Choose your hero", chooseHeroes);
            string chosenHero = heroList.SimpleMenu();
            Console.WriteLine($"You have chosen {chosenHero}!");
            Console.Write("Press Enter key to continue... ");
            Console.ReadLine();

            //Searchs for hero name and loads data from file to Class Hero, adds Class Hero to List<Hero> heroes
            foreach (string line in System.IO.File.ReadAllLines(path).ToList())
            {
                if ((line.Split(", ").ToList()[0]) == chosenHero)
                {
                    int HP = Int32.Parse(line.Split(", ").ToList()[1]);
                    int pla = Int32.Parse(line.Split(", ").ToList()[2]);
                    int atk = Int32.Parse(line.Split(", ").ToList()[3]);
                    string spe = line.Split(", ").ToList()[4];
                    int def = Int32.Parse(line.Split(", ").ToList()[5]);
                    string nameAlter = line.Split(", ").ToList()[6];
                    int rec = Int32.Parse(line.Split(", ").ToList()[7]);
                    int handSize = Int32.Parse(line.Split(", ").ToList()[8]);
                    int altHandSize = Int32.Parse(line.Split(", ").ToList()[9]);
                    string alterSpe = line.Split(", ").ToList()[10];

                    Hero newHero = new Hero(chosenHero, HP, pla, atk, spe, def, nameAlter, rec, handSize, altHandSize, alterSpe);

                    heroes.Add(newHero);
                }
            }
            //Removes hero from hero list, as each hero can only be picked once
            chooseHeroes.Remove(chosenHero);
            heroCount--;
        }

        return heroes;
    }

    static void HeroTurn(List<Hero> heroes, Villain villain)
    {
        foreach (Hero hero in heroes)
        {
            string input = "";

            while (input != "End Turn")
            {
                List<string> turnMenu = new List<string>
                {"Check Turn Options", "Recover Health", "Change to Hero", "End Turn"};
                if (hero.IsHero())
                {
                    turnMenu.Insert(1, $"Attack {villain.GetName()} (current HP: {villain.GetHP()})");
                    turnMenu.Insert(1, "Thwart Main Scheme");
                    turnMenu[4] = "Change to Alter-Ego";
                }

                string menuHeading = $"It is {hero.GetName()}'s Turn\n    HP: {hero.GetHP()}\nChoose one of the following";

                Menus menu = new Menus(menuHeading, turnMenu);
                input = menu.SimpleMenu();

                if (input == "Check Turn Options")
                {
                    Console.Clear();
                    Console.WriteLine("\n - Change Identity (only once)\n - Play a card from your Hand\n - Use a played card\n - Execute any Action ability\n - Ask a teammate to execute an Action ability\n");
                    Console.Write("Press Enter key to continue... "); Console.ReadLine();
                }

                else if (input == $"Attack {villain.GetName()} (current HP: {villain.GetHP()})")
                {
                    villain.Damage(hero.GetAtk());
                }
                else if (input == "Change to Hero" || input == "Change to Alter-Ego")
                {
                    hero.Change();
                }
            }
        }

    }

    static void VillainTurn(Villain name)
    {
        List<string> turnMenu = new List<string>
        {"Check Turn Options", "Change HP", "End Turn"};
        Menus menu = new Menus($"It is {name.GetName()}'s turn", turnMenu);
        menu.displayMenu();
    }

    static Scenario ScenarioSelector()
    {
        List<string> scenarios = new List<string>();
        string fileName = "Game Objects/Scenarios.txt";
        string chosen;
        string villain = "";
        string module = "";
        int threat = 0;
        int startThreat = 0;
        int roundThreat = 0;
        
        foreach (string line in System.IO.File.ReadAllLines(fileName).ToList())
        {
            scenarios.Add($"{line.Split(", ").ToList()[0]}");
        }
        Menus menu = new Menus("Scenarios", scenarios);
        chosen = menu.SimpleMenu();

        foreach (string line in System.IO.File.ReadAllLines(fileName).ToList())
        {
            if ((line.Split(", ").ToList()[0]) == chosen)
            {
                module = line.Split(", ").ToList()[1];
                villain = line.Split(", ").ToList()[2];
                threat = Int32.Parse(line.Split(", ").ToList()[3]);
                startThreat = Int32.Parse(line.Split(", ").ToList()[4]);
                roundThreat = Int32.Parse(line.Split(", ").ToList()[5]);
            }
        }       

        Console.WriteLine($"You have chosen to play {chosen}");
        Scenario newScene = new Scenario(chosen, villain, module, threat, startThreat, roundThreat);
        return newScene;
    }

    static Villain VillainSelector(string name)
    {
        string fileName = "Game Objects/Villains.txt";
        int hP = 0;
        int pla = 0;
        int atk = 0;
        string spe = "";

        foreach (string line in System.IO.File.ReadAllLines(fileName).ToList())
        {
            if ((line.Split(", ").ToList()[0]) == name)
            {
                hP = Int32.Parse(line.Split(", ").ToList()[1]);
                pla = Int32.Parse(line.Split(", ").ToList()[2]);
                atk = Int32.Parse(line.Split(", ").ToList()[3]);
                spe = line.Split(", ").ToList()[4];
            }
        }

        Villain villain = new Villain(name, hP, pla, atk, spe);

        return villain;
    }

    static List<Hero> CheckDeath(List<Hero> heroes)
    {
        foreach (Hero hero in heroes)
        {
            if (hero.GetHP() < 1)
            {
                heroes.Remove(hero);
            }
        }

        return heroes;
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