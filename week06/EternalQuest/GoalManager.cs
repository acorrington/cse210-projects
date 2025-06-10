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
        Console.WriteLine("Welcome to the Eternal Quest Goal Manager!");
        Console.WriteLine("This program allows you to create, manage, and track your goals.");

        int choice;
        do
        {
            Console.WriteLine("");
            DisplayPoints();
            Console.WriteLine("");
            DisplayMenu();
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        CreateGoal();
                        break;
                    case 2:
                        ListGoalDetails();
                        break;
                    case 3:
                        SaveGoals();
                        break;
                    case 4:
                        LoadGoals();
                        break;
                    case 5:
                        RecordEvent();
                        break;
                    case 6:
                        Console.WriteLine("Exiting the program.");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid number.");
            }
        } while (choice != 6);
    }

    public void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You have no goals yet.");
            return;
        }

        Console.WriteLine("Here are your goals:");
        foreach (Goal goal in _goals)
        {
            Console.WriteLine(goal.GetDetailsString());
        }
    }

    public void ListGoalNames()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You have no goals yet.");
            return;
        }

        Console.WriteLine("Here are your goals:");
        int goalNum = 1;
        foreach (Goal goal in _goals)
        {
            Console.WriteLine($"{goalNum}. {goal.GetName()}");
            goalNum++;
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");

        int choice;
        if (int.TryParse(Console.ReadLine(), out choice))
        {
            Goal goal = null;
            switch (choice)
            {
                case 1:
                    goal = SimpleGoal.Create();
                    break;
                case 2:
                    goal = EternalGoal.Create();
                    break;
                case 3:
                    goal = ChecklistGoal.Create();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    return;
            }
            _goals.Add(goal);
        }
        else
        {
            Console.WriteLine("Please enter a valid number.");
        }
    }

    public void RecordEvent()
    {
        ListGoalNames();

        if (_goals.Count != 0)
        {
            Console.Write("Enter the number of the goal you want to record an event for: ");
            int goalNum;
            while (!int.TryParse(Console.ReadLine(), out goalNum) && goalNum <= _goals.Count && goalNum > 0)
            {
                Console.Write("Please enter a valid goal number: ");
            }

            Goal selectedGoal = _goals[goalNum - 1];
            _score += selectedGoal.RecordEvent();
            Thread.Sleep(3000);
            DisplayFireworks();
        }
    }

    public void SaveGoals()
    {
        Console.Write("Enter filename to save goals: ");
        string filename = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(filename))
        {
            Console.WriteLine("Filename cannot be empty.");
            return;
        }

        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine($"Score:{_score}");

            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.Serialize());
            }
        }

        Console.WriteLine($"Goals saved to {filename}");
    }

    public void LoadGoals()
    {
        Console.Write("Enter filename to load goals: ");
        string filename = Console.ReadLine();

        if (File.Exists(filename))
        {
            _goals.Clear();

            string[] lines = File.ReadAllLines(filename);

            if (lines.Length > 0 && lines[0].StartsWith("Score:"))
            {
                _score = int.Parse(lines[0].Substring(6));
            }

            for (int i = 1; i < lines.Length; i++)
            {
                if (!string.IsNullOrWhiteSpace(lines[i]))
                {
                    Goal goal = Goal.Deserialize(lines[i]);
                    _goals.Add(goal);
                }
            }

            Console.WriteLine($"Goals loaded from {filename}.txt");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }

    private void DisplayPoints()
    {
        Console.WriteLine($"You have {_score} points.");
    }

    private void DisplayMenu()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("1. Create New Goal");
        Console.WriteLine("2. List Goals");
        Console.WriteLine("3. Save Goals");
        Console.WriteLine("4. Load Goals");
        Console.WriteLine("5. Record Event");
        Console.WriteLine("6. Quit");
        Console.Write("Select a choice from the menu: ");
    }

    private void DisplayFireworks()
    {        
        Console.CursorVisible = false;

        Random rand = new Random();
        int width = Console.WindowWidth;
        int height = Console.WindowHeight;

        for (int i = 0; i < 5; i++)
        {
            Console.Clear();
            int x = rand.Next(10, Math.Max(11, width - 10));
            int h = rand.Next(5, Math.Max(6, height - 5));
            for (int y = 0; y < h; y++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                int drawY = height - 2 - y;
                if (drawY >= 0 && x >= 0 && x < width)
                {
                    Console.SetCursorPosition(x, drawY);
                    Console.Write("^");
                }
                Thread.Sleep(50);
                if (drawY >= 0 && x >= 0 && x < width)
                {
                    Console.SetCursorPosition(x, drawY);
                    Console.Write(" ");
                }
            }

            Console.ForegroundColor = ConsoleColor.Red;
            int boomX = Math.Max(0, x - 6);
            int boomY = Math.Max(0, height - 2 - h);
            if (boomY < height && boomX < width)
            {
                Console.SetCursorPosition(boomX, boomY);
                Console.Write("* * BOOM! * *");
            }
            Thread.Sleep(500);
            Console.Clear();
        }

        Console.CursorVisible = true; 
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Cyan;
    }
}