public class ReflectingActivity : Activity
{
    static string name = "Reflecting";
    static string description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
    static List<string> prompts = new List<string>();
    static List<string> reflections = new List<string>();
    
    public ReflectingActivity() : base (name, description)
    {
        //populate lists
        prompts.Add("Think of a time when you stood up for someone else.");
        prompts.Add("Think of a time when you did something really difficult.");
        prompts.Add("Think of a time when you helped someone in need.");
        prompts.Add("Think of a time when you did something truly selfless.");
        reflections.Add("Why was this experience meaningful to you?");
        reflections.Add("Have you ever done anything like this before?");
        reflections.Add("How did you get started?");
        reflections.Add("How did you feel when it was complete?");
        reflections.Add("What made this time different than other times when you were not as successful?");
        reflections.Add("What is your favorite thing about this experience?");
        reflections.Add("What could you learn from this experience that applies to other situations?");
        reflections.Add("What did you learn about yourself through this experience?");
        reflections.Add("How can you keep this experience in mind in the future?");
    }

    public void ReflectionAct()
    {
        Random rnd = new Random();
        int rndNum = rnd.Next(prompts.Count() - 1);

        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine($"--- {prompts[rndNum]} ---");
        Console.Write("When you have something in mind press Enter to continue. ");
        Console.ReadLine();
        Console.WriteLine("Now ponder on each of the following questions as they relate to your experience.");
        Console.Write("You may begin in... ");
        Countdown(3);

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(int.Parse(_duration));

        while (DateTime.Now < endTime)
        {
            rndNum = rnd.Next(reflections.Count() - 1);
            Console.WriteLine($"\n > {reflections[rndNum]}");
            Waiting(5);
        }

        Console.WriteLine("Well Done!");
        Waiting(3);
    }
}