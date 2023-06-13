public class ListingActivity : Activity
{
    static string name = "Listing";
    static string description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
    static List<string> questions = new List<string>();
    public ListingActivity() : base (name, description)
    {
        //populate list
        questions.Add("Who are people that you appreciate?");
        questions.Add("What are personal strengths of yours?");
        questions.Add("Who are people that you have helped this week?");
        questions.Add("When have you felt the Holy Ghost this month?");
        questions.Add("Who are some of your personal heroes?");
    }

    public void ListAct()
    {
        Random rnd = new Random();
        int rndNum = rnd.Next(questions.Count() - 1);
        int counter = 0;

        Console.WriteLine("List as many responses as you can to the following question.");
        Console.WriteLine($"--- {questions[rndNum]} ---");
        Console.Write($"You may begin in... ");
        Countdown(3);

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(int.Parse(_duration));

        while (DateTime.Now < endTime)
        {
            Console.Write("\n >");
            Console.ReadLine();
            counter++;
        }

        Waiting(3);
        Console.WriteLine($"Great! You listed {counter} responses.");
        Waiting(3);

    }
}
