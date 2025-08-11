public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts;
    private Random _rand;

    public ListingActivity()
        : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _count = 0;
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
        _rand = new Random();
    }

    public void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine("--- " + GetRandomPrompt() + " ---");
        Console.Write("You may begin in: ");
        ShowCountDown(5);

        DateTime end = DateTime.Now.AddSeconds(_duration);
        _count = 0;
        while (DateTime.Now < end)
        {
            Console.Write(" > ");
            string response = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(response))
            {
                _count++;
            }
        }

        Console.WriteLine($"\nYou listed {_count} items!");
        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        int index = _rand.Next(_prompts.Count);
        return _prompts[index];
    }
}