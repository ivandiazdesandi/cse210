using System;

class Program
{
    static void Main(string[] args)
    {
        static void Main()
        {
            DisplayWelcome();
            string name = PromptUserName();
            int number = PromptUserNumber();
            DisplayResult(name, SquareNumber(number));
        }

        static void DisplayWelcome()
        {
            Console.WriteLine("Welcome to the Program!");
        }

        static string PromptUserName()
        {
            Console.Write("Please enter your name: ");
            string name = Console.ReadLine();
            return name;
        }

        static int PromptUserNumber()
        {
            Console.Write("Please enter your favorite number: ");
            string userInput = Console.ReadLine();
            int number = int.Parse(userInput);
            return number;
        }

        static int SquareNumber(int number)
        {
            int squareNum = number * number;
            return squareNum;
        }

        static void DisplayResult(string name, int number)
        {
            Console.WriteLine($"{name}, the square of your number is {number}");
        }

        Main();
    }
}