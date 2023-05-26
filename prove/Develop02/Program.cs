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
        List<string> entries = new List<string>();
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
                AddList(entries, Write());
            }
            else if(userOpt == "2")
            {
                Display(entries);
            }
            else if(userOpt == "3")
            {
                Console.Write("What is the name of the file you would like to load? ");
                string file = Console.ReadLine();
                if(File.Exists(file))
                {
                    entries.Clear();
                    entries = Load(entries, file);
                    Console.WriteLine($"Your file {file} has been loaded.");
                }
                else
                {
                    Console.WriteLine("File name does not exist.");
                }
            }
            else if(userOpt == "4")
            {
                Console.Write("How would you like to name your file? ");
                string file = Console.ReadLine();

                Save(entries, file);
            }
            else if(userOpt == "5")
            {
                return;
            }
            else
            {
                Console.WriteLine("Option does not exist. Try any number from 1-5.");
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

    public static void Display(List<string> entries)
    {
        Console.WriteLine("");

        foreach(string entry in entries)
        {
            Console.WriteLine(entry);
            Console.WriteLine("");
        }
    }

    public static void Save(List<string> toSave, string file)
    {
        string fileName = file;
        List<string> entries = new List<string>();
        entries = toSave;

        using (StreamWriter outputFile = new StreamWriter(fileName))
        foreach(string entry in entries)
        {
            outputFile.WriteLine(entry);
        }

        Console.WriteLine("Your entry has been saved.");
    }
    
    public static List<string> Load(List<string> entries, string file)
    {
        entries = System.IO.File.ReadLines(file).ToList();
            
        return entries;
    }

    public static List<string> AddList(List<string> list, string entry)
    {
        List<string> entries = new List<string>();
        entries = list;
        Entry entry1 = new Entry();
        entry1._date = GetDate();
        entry1._entry = entry;
        string newEntry = entry1.CreateEntry();

        entries.Add(newEntry);
        return entries;
    }
}

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void DisplayEntries()
    {
        foreach (Entry entry in _entries)
        {
            Console.WriteLine(entry.CreateEntry());
        }
    }
}

public class Entry
{
    public string _date;
    public string _entry;

    public string CreateEntry()
    {
        string newEntry = ($"{_date}\n     {_entry}");

        return newEntry;
    }
}