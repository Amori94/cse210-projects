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
            userOpt = MainMenu(userPoints);

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
                Console.Write("What is the name of the file?(Only name, not file type) ");
                string fileName = $"{Console.ReadLine()}.txt";
                goals = Load(fileName);

                string[] lines = System.IO.File.ReadAllLines(fileName);

                int points = Int32.Parse(lines[0]);

                userPoints = points;
                
            }

            else if (userOpt == 5)
            {
                Console.Clear();
                Console.WriteLine("These are the goals:");
                int i = 1;
                foreach (Goal goal in goals)
                {
                    Console.WriteLine($"    {i}. {goal.GetGoal()}");
                    i++;
                }

                Console.Write("Which goal did you accomplish? ");
                int chosenGoal = Int32.Parse(Console.ReadLine());

                if (goals[chosenGoal-1] is SimpleGoal)
                {
                    goals[chosenGoal-1].Completed();
                    int morePoints = goals[chosenGoal-1].GetPoints();
                    userPoints += morePoints;
                }

                else if (goals[chosenGoal-1] is EternalGoal)
                {
                    int morePoints = goals[chosenGoal-1].GetPoints();
                    userPoints += morePoints;
                }

                else if (goals[chosenGoal-1] is ChecklistGoal)
                {
                    goals[chosenGoal-1].AddPoints();
                    int morePoints = goals[chosenGoal-1].GetPoints();
                    userPoints += morePoints;

                    if((goals[chosenGoal-1].CheckCompleted()) == "X")
                    {
                        userPoints += goals[chosenGoal-1].GetBonus();
                    }
                                       
                }
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

    static int MainMenu(int points)
    {
        List<string> mainMenu = new List<string>
        {
            "Create Goal", "List Goals", "Save Goals", "Load Goals", "Record Event", "Quit"
        };

        Console.Clear();
        Console.WriteLine($"You have {points} points.");
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
        Console.Write("How would you like to name your file?(just name, no file type) ");
        string fileName = $"{Console.ReadLine()}.txt";
        
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            outputFile.WriteLine(points);
            foreach (Goal goal in goals)
            {
                outputFile.WriteLine(goal.SaveGoalFormat());
            }
        }

        Console.Clear();
        Console.WriteLine($"{fileName} has been saved... ");
        Console.Write("Press Enter to continue... ");
        Console.ReadLine();
    }

    static List<Goal> Load(string fileName)
    {
        List<Goal> goals = new List<Goal>();

        string[] lines = System.IO.File.ReadAllLines(fileName);

        lines = lines.Skip(1).ToArray();

        foreach (string line in lines)
        {
            string[] parts = line.Split(",");

            if (parts[0] == "SimpleGoal")
            {
                string name = parts[1];
                string description = parts[2];
                int ipoints = Int32.Parse(parts[3]);
                bool completed = bool.Parse(parts[4]);

                SimpleGoal goal = new SimpleGoal(name, description, ipoints);

                if (completed == true)
                {
                    goal.Completed();
                }

                goals.Add(goal);
            }
            else if (parts[0] == "EternalGoal")
            {
                string name = parts[1];
                string description = parts[2];
                int ipoints = Int32.Parse(parts[3]);

                EternalGoal goal = new EternalGoal(name, description, ipoints);  

                goals.Add(goal);
            }
            else if (parts[0] == "ChecklistGoal")
            {
                string name = parts[1];
                string description = parts[2];
                int ipoints = Int32.Parse(parts[3]);
                int bonus = Int32.Parse(parts[4]);
                int bonusPoints = Int32.Parse(parts[5]);
                int done = Int32.Parse(parts[6]);
                bool completed = bool.Parse(parts[7]);
                
                ChecklistGoal goal = new ChecklistGoal(name, description, ipoints, bonus, bonusPoints);
                goal.SetDone(done);

                if (completed == true)
                {
                    goal.Completed();
                }

                goals.Add(goal);
            }
        }

        Console.Clear();
        Console.WriteLine($"{fileName} has been loaded... ");
        Console.Write("Press Enter to continue... ");
        Console.ReadLine();

        return goals;
    }
}