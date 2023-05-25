using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string date = GetDate();
        Console.WriteLine("Welcome to Journal 1.0");
        Console.WriteLine($"Today is {date}...");

        ShowMenu();

        Console.WriteLine("See you later!");
    }

    static void ShowMenu()
    {
        string userOpt = "";
        List<string> menu = new List<string>
        {
            "1. Write", "2. Display", "3. Load", "4. Save", "5. Quit"
        };

        while(userOpt != "5")
        {
            Console.WriteLine("\nPlease choose one of the following...");

            foreach(string option in menu)
            {
                Console.WriteLine(option);
            }

            Console.Write("What would you like to do? ");
            userOpt = Console.ReadLine();

            if(userOpt == "1")
            {
                Write();
            }
            else if(userOpt == "2")
            {
                Display();
            }
            else if(userOpt == "3")
            {
                Load();
            }
            else if(userOpt == "4")
            {
                Save();
            }
            else if(userOpt == "5")
            {
                return;
            }
        }
    }

    public static string GetDate()
    {
        DateTime theCurrentTime = DateTime.Now;
        string date = theCurrentTime.ToShortDateString();

        return date;
    }
    
    public static string GetPrompt()
    {
        string filename = "Prompts.txt";
        List<string> lines = System.IO.File.ReadLines(filename).ToList();
        Random rnd = new Random();
        int rndNum = rnd.Next((lines.Count)-1);
        string prompt = lines[rndNum];

        return prompt;
    }

    public static string GetEntry()
    {
        string entry = Console.ReadLine();

        return entry;
    }

    public static string Write()
    {
        string prompt = GetPrompt();
        string userEntry;
        Console.WriteLine(prompt);
        userEntry = GetEntry();
        return userEntry;
    }

    public static void Display()
    {
        Console.WriteLine("Here you will see all entries");
    }

    public static void Save()
    {
        Console.WriteLine("Your entry has been saved.");
    }
    
    public static void Load()
    {
        Console.WriteLine("Your file has been loaded.");
    }
}

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void DisplayEntries()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }
}

public class Entry
{
    public string _date;
    public string _prompt;
    public string _entry;

    public void Display()
    {
        Console.WriteLine($"{_date} {_prompt} {_entry}");
    }
}