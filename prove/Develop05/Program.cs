using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        List<Goal> goals = new List<Goal>();
        int userPoints = 0;

        int userOpt = 0;

        while (userOpt != 6)
        {
            userOpt = MainMenu();

            if (userOpt == 1)
            {
                int option = GoalMenu();

                if (option == 1)
                {
                    Console.Write("What is the name of the goal? ");
                    string name = Console.ReadLine();
                    Console.Write("What is a short description of the goal? ");
                    string description = Console.ReadLine();
                    Console.Write("What is the goal worth in points? ");
                    int points = Int32.Parse(Console.ReadLine());

                    SimpleGoal goal = new SimpleGoal(name, description, points);
                    goals.Add(goal);
                }

                else if (option == 2)
                {
                    Console.Write("What is the name of the goal? ");
                    string name = Console.ReadLine();
                    Console.Write("What is a short description of the goal? ");
                    string description = Console.ReadLine();
                    Console.Write("What is the goal worth in points? ");
                    int points = Int32.Parse(Console.ReadLine());

                    EternalGoal goal = new EternalGoal(name, description, points);
                    goals.Add(goal);
                }

                else if (option == 3)
                {
                    Console.Write("What is the name of the goal? ");
                    string name = Console.ReadLine();
                    Console.Write("What is a short description of the goal? ");
                    string description = Console.ReadLine();
                    Console.Write("What is the goal worth in points? ");
                    int points = Int32.Parse(Console.ReadLine());
                    int bonus = Int32.Parse(Console.ReadLine());
                    int bonusPoints = Int32.Parse(Console.ReadLine());

                    ChecklistGoal goal = new ChecklistGoal(name, description, points, bonus, bonusPoints);
                    goals.Add(goal);
                }
            }

            else if (userOpt == 2)
            {
                Console.Clear();
                foreach (Goal goal in goals)
                {
                    Console.WriteLine($"[{goal.CheckCompleted()}] {goal.GetGoal()}");
                }

                Console.Write("Press enter to continue... ");
                Console.ReadLine();
            }

            else if (userOpt == 3)
            {
                Save(goals, userPoints);
            }

            else if (userOpt == 4)
            {
                
            }

            else if (userOpt == 5)
            {
                
            }
        }

    }

    static int GoalMenu()
    {
        List<string> goalMenu = new List<string>
        {
            "Simple Goal", "Eternal Goal", "Checklist Goal"
        };

        Console.Clear();
        Console.WriteLine("Goals Menu:");

        int i = 1;

        foreach (string menu in goalMenu)
        {
            Console.WriteLine($"    {i}. {menu}");
            i++;
        }

        Console.Write("Which type of goal would you like to make? ");
        int option = Int32.Parse(Console.ReadLine());

        return option;
    }

    static int MainMenu()
    {
        List<string> mainMenu = new List<string>
        {
            "Create Goal", "List Goals", "Save Goals", "Load Goals", "Record Event", "Quit"
        };

        Console.Clear();
        Console.WriteLine("Main Menu:");

        int i = 1;

        foreach (string menu in mainMenu)
        {
            Console.WriteLine($"    {i}. {menu}");
            i++;
        }

        Console.Write("Choose an option from the menu: ");
        int userOpt = Int32.Parse(Console.ReadLine());

        return userOpt;
    }

    static void Save(List<Goal> goals, int points)
    {
        Console.Write("How would you like to name your file? (just name, no file type)");
        string fileName = $"{Console.ReadLine()}.txt";
        
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            outputFile.WriteLine(points);
            foreach (Goal goal in goals)
            {
                outputFile.WriteLine(goal.GetGoal());
            }
        }
    }
}