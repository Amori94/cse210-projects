using System;

class Program
{
    static void Main(string[] args)
    {
        string input = "";
        bool loaded = false;
        Console.WriteLine("MARVEL CHAMPIONS COMPANION");

        while (input != "Quit")
        {
            input = DisplayMainMenu(loaded);

            if (input == "New Game")
            {
                Hero hero = new Hero("Spider",10,2,3,"extra res","Peter",3,6,"Extra resource");
                HeroTurn(hero,1);
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