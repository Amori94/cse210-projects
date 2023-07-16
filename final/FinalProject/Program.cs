using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string input = "";
        bool loaded = false;
        string fileName = "";

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
                InitiateSavedGame(fileName);
            }

            else if (input == "Load Game")
            {
                fileName = LoadGame();
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

        string fileName = menu.SimpleMenu();

        Console.Clear();
        Console.Write($"{fileName} has been loaded correctly.\n Press Enter to continue... ");
        Console.ReadLine();

        return fileName;
    }

    static void SaveGame(Scenario scenario, Villain villain, List<Hero> heroes)
    {
        Console.Write("How would you like to name your file?");
        string fileName = $"Saved Files\\{Console.ReadLine()}.txt";
        
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            outputFile.WriteLine(scenario.ExportData());
            outputFile.WriteLine(villain.ExportData());
            foreach (Hero hero in heroes)
            {
                outputFile.WriteLine(hero.ExportData());
            }
        }

        Console.Write("Saving... ");
        Countdown(3);
        Console.Clear();
        Console.WriteLine("Your game was saved");

        //prompt quit
        Console.Write("Would you like to Quit the program?(y/n) ");
        string quitGame = Console.ReadLine();
        if (quitGame == "y")
        {
            Environment.Exit(0);
        }
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
        Console.Clear();
        Console.WriteLine($"You are playing against {scenario.GetVillain()} in {scenario.GetName()} on {scenario.GetDifficulty()} mode.");
        Console.WriteLine("The heroes are: ");
        foreach (Hero hero in heroes)
        {
            Console.WriteLine($"-----{hero.GetName()}\n - HP = {hero.GetHP()}\n - REC = {hero.GetRec()}\n - ATK = {hero.GetAtk()}\n - DEF = {hero.GetDef()}\n - THW = {hero.GetPla()}");
        }

        Console.WriteLine("Press Enter key to continue..."); Console.ReadLine();

        Game(scenario, heroes, villain);
    }

    static void InitiateSavedGame(string fileName)
    {
        //load file to string[]
        string[] lines = System.IO.File.ReadAllLines($"Saved Files\\{fileName}");

        //initiate scenario and load
        Scenario scenario = new Scenario();
        scenario.Loader(lines[0]);

        //initiate villain and load
        Villain villain = new Villain();
        villain.Loader(lines[1]);

        //load heroes
        int lineCount = File.ReadLines($"Saved Files\\{fileName}").Count();
        List<Hero> heroes = new List<Hero>();

        for (int i = 2; i < lineCount; i++)
        {
            Hero hero = new Hero();
            hero.Loader(lines[i]);
            heroes.Add(hero);
        }

        //set initial stats
        Console.Clear();
        Console.WriteLine($"You are playing against {scenario.GetVillain()} in {scenario.GetName()} on {scenario.GetDifficulty()} mode.");
        Console.WriteLine("The heroes are: ");
        foreach (Hero hero in heroes)
        {
            Console.WriteLine($"-----{hero.GetName()}\n - HP = {hero.GetHP()}\n - REC = {hero.GetRec()}\n - ATK = {hero.GetAtk()}\n - DEF = {hero.GetDef()}\n - THW = {hero.GetPla()}");
        }

        Console.WriteLine("Press Enter key to continue..."); Console.ReadLine();

        Game(scenario, heroes, villain);
    }

    static void Game(Scenario scenario, List<Hero> heroes, Villain villain)
    {
        bool endGame = false;
        bool villainIsDead = false;
        bool scenarioEnd = false;

        while (!endGame)
        {
            CheckHDeath(heroes);
            villainIsDead = CheckVDeath(villain);
            scenarioEnd = CheckEnd(scenario);

            if (!heroes.Any() || villainIsDead || scenarioEnd)
            {
                endGame = true;
            }

            else
            {
                HeroTurn(heroes, villain, scenario);
                villainIsDead = CheckVDeath(villain);
                if (villainIsDead)
                {
                    endGame = true;
                }
                else {VillainTurn(villain, heroes, scenario);}
            }

            Console.Clear();
        }

        Console.WriteLine("The game is finished.");
        if (villainIsDead)
        {
            Console.WriteLine($"{villain.GetName()} has been defeated! The heroes have triumphed this time!");
            Console.WriteLine("You won!");
        }
        else if (scenarioEnd)
        {
            Console.WriteLine($"The Main Scheme has been completed! {villain.GetName()} has won this time!");
            Console.WriteLine("You lost!");
        }
        else {Console.WriteLine($"All the heroes have lost, {villain.GetName()} has won this time!");Console.WriteLine("You lost!");}

        Console.Write("Press Enter key to continue... ");
        Console.ReadLine();
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

    static void HeroTurn(List<Hero> heroes, Villain villain, Scenario scenario)
    {
        foreach (Hero hero in heroes)
        {
            string input = "";

            while (input != "End Turn")
            {
                List<string> turnMenu = new List<string>
                {"Check Turn Options", "Recover Health", "Change to Hero", "End Turn", "Save Game"};
                if (hero.IsHero())
                {
                    turnMenu.Insert(1, $"Attack {villain.GetName()} (current HP: {villain.GetHP()})");
                    turnMenu.Insert(1, $"Interrupt Main Scheme (current Threat: {scenario.GetThreat()}) of {scenario.GetEndThreat()}");
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

                else if (input == "Recover Health")
                {
                    hero.Recovery(hero.GetRec());
                }

                else if (input == $"Attack {villain.GetName()} (current HP: {villain.GetHP()})")
                {
                    villain.Damage(hero.GetAtk());
                }

                else if (input == "Interrupt Main Scheme")
                {
                    scenario.Interrupt(hero.GetPla());
                }

                else if (input == "Change to Hero" || input == "Change to Alter-Ego")
                {
                    hero.Change();
                }

                else if (input == "Save Game")
                {
                    SaveGame(scenario, villain, heroes);
                }
            }
        }

        string userIn = "";

        while (userIn != "End Turn")
        {
            List<string> turnMenu = new List<string>
            {"Update Hero Health", "Update Villain Health", "Update Main Scheme Threat", "End Turn", "Save Game"};

            string menuHeading = $"Update Manually any card effects... ";

            Menus menu = new Menus(menuHeading, turnMenu);
            userIn = menu.SimpleMenu();

            if (userIn == "Update Hero Health")
            {
                foreach (Hero hero in heroes)
                {
                    Console.WriteLine($"{hero.GetName()} current Health = {hero.GetHP()}");
                    Console.Write($"How much more damage did {hero.GetName()} receive? ");
                    int points = int.Parse(Console.ReadLine());
                    hero.Damage(points);
                    Console.Write($"{hero.GetName()} current HP = {hero.GetHP()}\n\n Press enter to continue... "); Console.ReadLine();
                }
            }

            else if (userIn == "Update Villain Health")
            {
                Console.WriteLine($"{villain.GetName()} current Health = {villain.GetHP()}");

                Console.Write($"Did {villain.GetName()} recover (1) or lose health (2)");
                string recOrDam = Console.ReadLine();
                if (recOrDam == "1")
                {
                    Console.Write($"How much health did {villain.GetName()} recover? ");
                    int points = int.Parse(Console.ReadLine());
                    villain.Recovery(points);
                }
                else
                {
                    Console.Write($"How much health did {villain.GetName()} lose? ");
                    int points = int.Parse(Console.ReadLine());
                    villain.Damage(points);
                }

                Console.Write($"{villain.GetName()} current HP = {villain.GetHP()}\n\n Press enter to continue... "); Console.ReadLine();
            }

            else if (userIn == "Update Main Scheme Threat")
            {                    
                Console.WriteLine($"Main Scheme current Threat = {scenario.GetThreat()}/{scenario.GetEndThreat()}\n\n Press Enter to continue... ");
                Console.Write($"How much threat did {villain.GetName()} add? ");
                int points = int.Parse(Console.ReadLine());
                scenario.Plan(points);
                Console.Write($"Main Scheme current Threat = {scenario.GetThreat()}/{scenario.GetEndThreat()}\n\n Press Enter to continue... "); Console.ReadLine();
            }

            else if (userIn == "Save Game")
            {
                SaveGame(scenario, villain, heroes);
            }
        }

    }

    static void VillainTurn(Villain villain, List<Hero> heroes, Scenario scenario)
    {
        string name = villain.GetName();
        string mainScheme = scenario.GetName();
        int threatRise = scenario.GetRoundThreat();
        int threat = scenario.GetThreat();
        int atk = villain.GetAtk();
        int pla = villain.GetPla();

        //Place threat on main scheme
        Console.Clear();
        Console.WriteLine($"It is {name}'s turn!!!\n Current HP = {villain.GetHP()}\n Main Scheme Current Threat = {scenario.GetThreat()}/{scenario.GetEndThreat()}");
        Console.WriteLine($"The main scheme {mainScheme} rises {threatRise} points");
        scenario.Plan(threatRise);
        Console.Write("Press Enter to Continue..."); Console.ReadLine();

        //Villain activates agains each hero/alterego
        foreach (Hero hero in heroes)
        {
            Console.Clear();
            Console.WriteLine($"It is {name}'s turn!!!\n Current HP = {villain.GetHP()}\n Main Scheme Current Threat = {scenario.GetThreat()}/{scenario.GetEndThreat()}\n\n");

            if (hero.IsHero())
            {
                Console.WriteLine($"{name} attacks {hero.GetName()} with a base of {atk}.\n Reveal a card from the encounter deck.\n Add any extra damage");
                Console.Write($"How much damage did {hero.GetName()} receive? ");
                int points = int.Parse(Console.ReadLine());
                hero.Damage(points);
                Console.Write($"{hero.GetName()} current HP = {hero.GetHP()}\n\n Press enter to continue... "); Console.ReadLine();
            }
            else 
            {
                Console.WriteLine($"While {hero.GetName()} recovers, {name} plans with a base of {pla}.\n Reveal a card from the encounter deck.\n Add any extra plan");
                Console.Write($"How much threat did {name} add to the Main Scheme? ");
                int points = int.Parse(Console.ReadLine());
                scenario.Plan(points);
                Console.Write($"Main Scheme current Threat = {scenario.GetThreat()}/{scenario.GetEndThreat()}\n\n Press Enter to continue... "); Console.ReadLine();
            }
        }

        //Follow instructions
        Console.Clear();
        Console.WriteLine($"It is {name}'s turn!!!\n Current HP = {villain.GetHP()}\n Main Scheme Current Threat = {scenario.GetThreat()}/{scenario.GetEndThreat()}");
        Console.WriteLine("Deal 1 card from the encounter deck to each player.");
        Console.Write("Press Enter to Continue..."); Console.ReadLine();
        Console.WriteLine("Reveal each encounter card and play its effect.");
        Console.Write("Press Enter to Continue..."); Console.ReadLine();

        //Update stats manually
        string input = "";

        Console.Clear();
        Console.WriteLine($"It is {name}'s turn!!!\n Current HP = {villain.GetHP()}\n Main Scheme Current Threat = {scenario.GetThreat()}/{scenario.GetEndThreat()}");

        while (input != "End Turn")
        {
            List<string> turnMenu = new List<string>
            {"Update Hero Health", "Update Villain Health", "Update Main Scheme Threat", "End Turn", "Save Game"};

            string menuHeading = $"Update Manually any card effects... ";

            Menus menu = new Menus(menuHeading, turnMenu);
            input = menu.SimpleMenu();

            if (input == "Update Hero Health")
            {
                foreach (Hero hero in heroes)
                {
                    Console.WriteLine($"{hero.GetName()} current Health = {hero.GetHP()}");
                    Console.Write($"How much more damage did {hero.GetName()} receive? ");
                    int points = int.Parse(Console.ReadLine());
                    hero.Damage(points);
                    Console.Write($"{hero.GetName()} current HP = {hero.GetHP()}\n\n Press enter to continue... "); Console.ReadLine();
                }
            }

            else if (input == "Update Villain Health")
            {
                Console.WriteLine($"{name} current Health = {villain.GetHP()}");

                Console.Write($"Did {name} recover (1) or lose health (2)");
                string recOrDam = Console.ReadLine();
                if (recOrDam == "1")
                {
                    Console.Write($"How much health did {name} recover? ");
                    int points = int.Parse(Console.ReadLine());
                    villain.Recovery(points);
                }
                else
                {
                    Console.Write($"How much health did {name} lose? ");
                    int points = int.Parse(Console.ReadLine());
                    villain.Damage(points);
                }

                Console.Write($"{name} current HP = {villain.GetHP()}\n\n Press enter to continue... "); Console.ReadLine();
            }

            else if (input == "Update Main Scheme Threat")
            {                    
                Console.WriteLine($"Main Scheme current Threat = {scenario.GetThreat()}/{scenario.GetEndThreat()}\n\n Press Enter to continue... ");
                Console.Write($"How much threat did {name} add? ");
                int points = int.Parse(Console.ReadLine());
                scenario.Plan(points);
                Console.Write($"Main Scheme current Threat = {scenario.GetThreat()}/{scenario.GetEndThreat()}\n\n Press Enter to continue... "); Console.ReadLine();
            }

            else if (input == "Save Game")
            {
                SaveGame(scenario, villain, heroes);
            }
        }

        Console.WriteLine($"");
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

    static List<Hero> CheckHDeath(List<Hero> heroes)
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

    static bool CheckVDeath (Villain villain)
    {
        bool isDead = false;

        if (villain.GetHP() < 1)
        {
            isDead = true;
        }

        return isDead;
    }

    static bool CheckEnd(Scenario scenario)
    {
        bool end = false;

        if (scenario.GetThreat() > (scenario.GetEndThreat() - 1))
        {
            end = true;
        }

        return end;
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