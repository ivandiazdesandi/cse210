public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        bool running = true;
        while (running)
        {
            Console.Clear();
            DisplayPlayerInfo();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Please enter a valid option (1-6).");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points.\n");
    }

    public void ListGoalNames()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetShortName()}");
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("Your Goals:");
        if (_goals.Count == 0)
        {
            Console.WriteLine("  (none)");
            return;
        }
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string type = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string desc = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        if (type == "1")
        {
            _goals.Add(new SimpleGoal(name, desc, points));
        }
        else if (type == "2")
        {
            _goals.Add(new EternalGoal(name, desc, points));
        }
        else if (type == "3")
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int target = int.Parse(Console.ReadLine());
            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bonus = int.Parse(Console.ReadLine());
            _goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
        }
        else
        {
            Console.WriteLine("Invalid type.");
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals to record. Create one first.");
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
            return;
        }

        Console.WriteLine("Which goal did you accomplish?");
        ListGoalNames();
        Console.Write("Select a goal: ");
        int index = int.Parse(Console.ReadLine()) - 1;
        if (index < 0 || index >= _goals.Count)
        {
            Console.WriteLine("Invalid selection.");
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
            return;
        }

        int earned = _goals[index].RecordEvent();
        _score += earned;
        Console.WriteLine($"Congratulations! You have earned {earned} points!");
        Console.WriteLine($"You now have {_score} points.");
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();
        using (StreamWriter output = new StreamWriter(filename))
        {
            output.WriteLine(_score);
            foreach (Goal g in _goals)
            {
                output.WriteLine(g.GetStringRepresentation());
            }
        }
        Console.WriteLine("Saved.");
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
            return;
        }

        _goals.Clear();
        using (StreamReader input = new StreamReader(filename))
        {
            string first = input.ReadLine();
            int.TryParse(first, out _score);

            string line;
            while ((line = input.ReadLine()) != null)
            {
                string[] parts = line.Split('|');
                string type = parts[0];
                if (type == "SimpleGoal")
                {
                    string name = parts[1];
                    string desc = parts[2];
                    int points = int.Parse(parts[3]);
                    bool isComplete = bool.Parse(parts[4]);
                    var g = new SimpleGoal(name, desc, points);
                    if (isComplete)
                    {
                        g.RecordEvent();
                    }
                    _goals.Add(g);
                }
                else if (type == "EternalGoal")
                {
                    string name = parts[1];
                    string desc = parts[2];
                    int points = int.Parse(parts[3]);
                    _goals.Add(new EternalGoal(name, desc, points));
                }
                else if (type == "ChecklistGoal")
                {
                    string name = parts[1];
                    string desc = parts[2];
                    int points = int.Parse(parts[3]);
                    int amountCompleted = int.Parse(parts[4]);
                    int target = int.Parse(parts[5]);
                    int bonus = int.Parse(parts[6]);
                    var g = new ChecklistGoal(name, desc, points, target, bonus);
                    for (int i = 0; i < amountCompleted; i++)
                    {
                        g.RecordEvent();
                    }
                    _goals.Add(g);
                }
            }
        }
        Console.WriteLine("Loaded.");
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }
}