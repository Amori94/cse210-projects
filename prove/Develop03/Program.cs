using System;

class Program
{
    static void Main(string[] args)
    {
        string userOpt = "";
        
        Console.Clear();
        Console.WriteLine("Choose a scripture from 1-4:\n");
        Reference show = new Reference();
        show.ShowAllRef();

        string selector = Console.ReadLine();

        Scripture scripture = new Scripture(selector);
        Reference reference = new Reference(selector);
        int scriptureLong = scripture.GetScriptureList().Count();

        while (userOpt != "quit")
        {
            Console.Clear();
            Console.WriteLine($"{reference.GetUserRef()}{scripture.GetScripture()}");
            Console.Write("\nPress enter to continue or type 'quit' to finish: ");

            userOpt = Console.ReadLine();

            if(scripture.FullHidden() == true)
            {
                userOpt = "quit";
            }

            if (scriptureLong > 2)
            {
                for (int i = 0; i < 3; i++)
                {
                    scripture.SwapWord();
                    scriptureLong = scriptureLong - 1;
                }
            }
            else if (scriptureLong == 2)
            {
                scripture.SwapWord();
                scripture.SwapWord();
                scriptureLong = scriptureLong - 2;
            }
            else if (scriptureLong == 1)
            {
                scripture.SwapWord();
                scriptureLong = scriptureLong - 1;
            }
            
        }
    }
}