using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your porcentage grade? ");
        string userValue = Console.ReadLine();
        int userValueNum = int.Parse(userValue);
        string letterGrade = "";
        string pass = "";

        if (userValueNum >= 90)
        {
            letterGrade = "A";
            pass = "passed";
        }

        else if (userValueNum >= 80)
        {
            letterGrade = "B";
            pass = "passed";
        }

        else if (userValueNum >= 7)
        {
            letterGrade = "C";
            pass = "passed";
        }

        else if (userValueNum >= 60)
        {
            letterGrade = "D";
            pass = "not passed";
        }

        else
        {
            letterGrade = "F";
            pass = "not passed";
        }

        Console.WriteLine($"You have scored a {letterGrade}.");
        Console.WriteLine($"You have {pass}.");
        
    }
}