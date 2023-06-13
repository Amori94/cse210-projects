public class BreathingActivity : Activity
{
    static string name = "Breathing";
    static string description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on you breathing.";
    public BreathingActivity() : base (name, description)
    {

    }
    
    public void BreathSeq()
    {
        Console.WriteLine("Get Ready...");
        Waiting(5);
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(int.Parse(_duration));
        while (DateTime.Now < endTime)
        {
            Console.WriteLine("Breath in...\n\n");
            Waiting(5);
            Console.WriteLine("Hold breath...\n\n");
            Waiting(5);
            Console.WriteLine("Breath out...\n\n");
            Waiting(5);
            Console.WriteLine("Hold breath...\n\n");
            Waiting(5);  
        }

        Console.WriteLine("Well Done!");
        Waiting(3);
    }
}