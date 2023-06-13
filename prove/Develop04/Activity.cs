using System.Reflection;

public class Activity
{
    private string _activityName;
    private string _description;
    protected string _duration;

    public Activity(string activityName, string description)
    {
        _activityName = activityName;
        _description = description;
    }

    public void DisplayStartMsg()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_activityName} Activity.\n");
        Console.WriteLine($"{_description} \n");
        Console.Write("How long would you like your session to be? ");
        _duration = Console.ReadLine();
        Console.Clear();
        Console.WriteLine("Get Ready...");
        Countdown(3);
    }

    public void DisplayEndMsg()
    {
        Console.Clear();
        Console.WriteLine($"You have completed {_duration} seconds of {_activityName} Activity.\n");
        _duration = "0";
        Waiting(5);
    }

    public void Waiting(int repeat)
    {
        for (int i = 0; i < repeat; i++)
        {
            Console.CursorVisible = false;

            List<string> animationString = new List<string>();
            animationString.Add("|");
            animationString.Add("/");
            animationString.Add("-");
            animationString.Add("\\");
            animationString.Add("|");
            animationString.Add("/");
            animationString.Add("-");
            animationString.Add("\\");

            foreach (string s in animationString)
            {
                
                Console.Write(s);
                Thread.Sleep(125);
                Console.Write("\b \b");
            }

            Console.CursorVisible = true;
        }
    }

    public void Countdown(int start)
    {
        Console.CursorVisible = false;

        while (start != 0)
        {
                Console.Write(start);
                Thread.Sleep(1000);
                Console.Write("\b \b");
                start--;
        }

        Console.CursorVisible = true;
    }
}