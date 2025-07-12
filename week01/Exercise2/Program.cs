using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string userInput = Console.ReadLine();
        int grade = int.Parse(userInput);
        string letter = ("");

        if (grade >= 90)
        {
            letter = ("A");
        }
        else if (grade >= 80)
        {
            letter = ("B");
        }
        else if (grade >= 70)
        {
            letter = ("C");
        }
        else if (grade >= 60)
        {
            letter = ("D");
        }
        else if (grade < 60)
        {
            letter = ("F");
        }
        else
        {
            Console.WriteLine("Please enter a valid number form 0 to 100");
        }

        Console.WriteLine($"Your grade is {letter}");

        if (grade >= 70)
        {
            Console.WriteLine("Congratulations you have passed!");
        }
        else if (grade <= 69)
        {
            Console.WriteLine("This is not the end of the road, prepare yourself better and try again!");
        }

    }
}