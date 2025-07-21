using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        string userChoice = "";
        while (userChoice != "5")
        {
            Console.WriteLine("\nPlease choose one of the following options:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");

            Console.Write("Enter your choice: ");
            userChoice = Console.ReadLine();

            if (userChoice == "1")
            {
                string prompt = promptGenerator.GetRandomPrompt();
                Console.WriteLine($"\nPrompt: {prompt}");
                Console.Write("Your response: ");
                string response = Console.ReadLine();

                Entry newEntry = new Entry();
                newEntry._promptText = prompt;
                newEntry._entryText = response;
                newEntry._date = DateTime.Now.ToString("dd/MM/yyyy");

                journal.AddEntry(newEntry);
            }
            else if (userChoice == "2")
            {
                journal.DisplayAll();
            }
            else if (userChoice == "3")
            {
                Console.Write("Enter a filename to save to: ");
                string filename = Console.ReadLine();
                journal.SaveToFile(filename);
            }
            else if (userChoice == "4")
            {
                Console.Write("Enter a filename to load from: ");
                string filename = Console.ReadLine();
                journal.LoadFromFile(filename);
            }
            else if (userChoice == "5")
            {
                Console.WriteLine("Goodbye!");
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }
    }
}
