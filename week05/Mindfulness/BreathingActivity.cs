public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        int elapsed = 0;
        while (elapsed < _duration)
        {
            Console.Write("\nBreathe in... ");
            ShowCountDown(4);
            elapsed += 4;
            if (elapsed >= _duration) break;

            Console.Write("\nBreathe out... ");
            ShowCountDown(4);
            elapsed += 4;
        }

        DisplayEndingMessage();
    }
}