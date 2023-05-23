using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        int userNum;
        int numberSum = 0;
        float numberAvg;
        int maxNumber;
        List<int> numbers = new List<int>();
        

        do
        {
            Console.Write("Enter number: ");
            string userInput = Console.ReadLine();
            userNum = int.Parse(userInput);
            if (userNum != 0)
            {
                numbers.Add(userNum);
            }

        } while (userNum != 0);

        foreach (int num in numbers)
        {
            numberSum = numberSum + num;
        }

        Console.WriteLine($"The sum is: {numberSum}");

        numberAvg = ((float)numberSum) / numbers.Count;

        Console.WriteLine($"The average is: {numberAvg}");

        maxNumber = numbers.Max();

        Console.WriteLine($"The largest number is: {maxNumber}");

    }
}