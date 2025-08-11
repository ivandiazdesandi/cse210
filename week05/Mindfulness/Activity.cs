public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
        _duration = 0;
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name} Activity.\n");
        Console.WriteLine(_description + "\n");

        Console.Write("How long, in seconds, would you like for your session? ");
        string input = Console.ReadLine();
        int seconds;
        if (!int.TryParse(input, out seconds) || seconds < 1)
        {
            seconds = 10;
        }
        _duration = seconds;

        Console.WriteLine("\nGet ready...");
        ShowSpinner(3);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("\nWell done!");
        ShowSpinner(2);
        Console.WriteLine($"You have completed the {_name} Activity for {_duration} seconds.");
        ShowSpinner(3);
    }

    protected void ShowSpinner(int seconds)
    {
        char[] frames = new char[] { '|', '/', '-', '\\' };
        DateTime end = DateTime.Now.AddSeconds(seconds);
        int i = 0;
        while (DateTime.Now < end)
        {
            Console.Write(frames[i % frames.Length]);
            Thread.Sleep(200);
            Console.Write('\b');
            i++;
        }
        Console.Write(' ');
        Console.Write('\b');
    }

    protected void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            string s = i.ToString();
            Console.Write(s);
            Thread.Sleep(1000);
            Console.Write(new string('\b', s.Length));
            Console.Write(new string(' ', s.Length));
            Console.Write(new string('\b', s.Length));
        }
    }
}