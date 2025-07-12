using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        int number = 1;
        List<int> listNumbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        do
        {
            Console.Write("Enter number: ");
            string userInput = Console.ReadLine();
            number = int.Parse(userInput);

            if (number != 0)
            {
                listNumbers.Add(number);
            }
        } while (number != 0);

        int total = 0;
        int largeNumber = 0;

        foreach (int index in listNumbers)
        {
            total = index + total;
            if (index > largeNumber)
            {
                largeNumber = index;
            }
        }

        float average = ((float)total / listNumbers.Count);

        Console.WriteLine($"The sum is: {total}");
        Console.WriteLine($"The average is {average}");
        Console.WriteLine($"The largest number is: {largeNumber}");
    }
}