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
        int input;
        int i = 1;

        //display main menu
        Console.Clear();
        Console.WriteLine("Main Menu");

        foreach (string name in mainMenu)
        {
            Console.WriteLine($"    {i}. {name}");
            i++;
        }

        //get user input to choose menu option
        Console.Write("Choose an option from the menu: ");
        input = Int32.Parse(Console.ReadLine());

        return mainMenu[input - 1];
    }

    static string LoadGame()
    {   
        //get file names in variable, initiate i variable
        string path = "Saved Files";
        string[] savedGames = Directory.GetFiles(path);
        int i = 1;
        int chosenFile;

        //display file names
        Console.Clear();
        Console.WriteLine("Saved Games:");

        foreach(string name in savedGames)
        {
            Console.WriteLine($"    {i} - {Path.GetFileName(name)}.");
            i++;
        }

        //get user input to load correct game
        Console.Write("What game would you like to load? ");
        chosenFile = Int32.Parse(Console.ReadLine());

        return savedGames[chosenFile - 1];
    }

    static void GameLoader(string fileName)
    {
        Console.Clear();
        Console.Write($"{fileName} has been loaded correctly.\n Press Enter to continue... ");
        Console.ReadLine();
    }
}