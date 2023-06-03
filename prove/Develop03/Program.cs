using System;

class Program
{
    static void Main(string[] args)
    {
        string userOpt = "";
        string scripture;
        string reference;
        
        Console.Clear();
        Console.WriteLine("Choose a scripture from 1-4:\n");
        Reference show = new Reference();
        show.ShowAllRef();

        string scriptSelector = Console.ReadLine();

        Scripture chooseScripture = new Scripture(scriptSelector);
        scripture = chooseScripture.GetScripture();
        Reference userRef = new Reference(scriptSelector);
        reference = userRef.GetUserRef();

        while (userOpt != "quit")
        {
            Console.Clear();
            Console.WriteLine($"{reference}{scripture}");
            Console.Write("\nPress enter to continue or type 'quit' to finish: ");

            userOpt = Console.ReadLine();

            bool result = !scripture.Any(x => char.IsLetter(x));

            if(result == true)
            {
                userOpt = "quit";
            }

            List<string> listScripture = new List<string>();

            foreach (string word in scripture.Split(" "))
            {
                listScripture.Add(word);
            }
            for (int i = 0; i < 2; i++)
            {
                Random rnd = new Random();
                int rndNum = rnd.Next(listScripture.Count());
                string underScores = "";

                if (!(listScripture[rndNum].Contains("_")))
                {                
                    foreach (char letter in listScripture[rndNum])
                        {
                            underScores = underScores + "_";
                        }

                    listScripture[rndNum] = underScores;
                }
            }
            scripture = string.Join(" ", listScripture);
        }
    }
}