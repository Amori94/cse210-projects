using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();

        string userName = PromptUserName();
        int userNum = PromptUserNum();

        int squaredNum = SquareNumber(userNum);
        string squaredStr = squaredNum.ToString();

        DisplayResult(userName, squaredStr);
    }

    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }

    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string userName1 = Console.ReadLine();

        return userName1;
    }

    static int PromptUserNum()
    {
        Console.Write("Please enter your favorite number: ");
        string userInput = Console.ReadLine();
        int userNum = int.Parse(userInput);

        return userNum;
    }

    static int SquareNumber(int userNum)
    {
        int squaredNum = userNum * userNum;

        return squaredNum;
    }

    static void DisplayResult(string userName, string square)
    {
        Console.WriteLine($"{userName}, the square of your number is {square}.");
    }
}