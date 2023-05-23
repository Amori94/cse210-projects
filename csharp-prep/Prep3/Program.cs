using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Guess the magic number!");
        string playAgain = "y";

        while (playAgain == "y")
        {
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 100);
            
            int guessNum = 0;
            int guessCounter = 0;

            while (guessNum != magicNumber)
            {
                Console.Write("What is your guess? ");
                string userGuess = Console.ReadLine();
                guessNum = int.Parse(userGuess);
                guessCounter = guessCounter + 1;

                if (guessNum < magicNumber)
                {
                    Console.WriteLine("Higher");

                }
                else if (guessNum > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
            }

            Console.WriteLine($"You guessed it in {guessCounter} times!");
            Console.Write("Would you like to play again?(y/n) ");
            playAgain = Console.ReadLine();
        }
    }
}