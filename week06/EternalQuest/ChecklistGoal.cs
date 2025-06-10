public class ChecklistGoal : Goal
{
    protected int _amountCompleted;
    protected int _target;
    protected int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus)
        : base(name, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

    // Private constructor for deserialization
    private ChecklistGoal(string name, string description, int points, int target, int bonus, int amountCompleted)
        : base(name, description, points)
    {
        _amountCompleted = amountCompleted;
        _target = target;
        _bonus = bonus;
    }

    public override int RecordEvent()
    {
        if (_amountCompleted < _target)
        {
            _amountCompleted++;
            Console.WriteLine($"Goal '{_name}' progress: {_amountCompleted}/{_target}. You earned {_points} points.");
            if (_amountCompleted == _target)
            {
                Console.WriteLine($"Goal '{_name}' completed! You earned a bonus of {_bonus} points.");
                return _points + _bonus;
            }
            else
            {
                return _points;
            }
        }
        else
        {
            Console.WriteLine($"Goal '{_name}' is already completed.");
            return 0;
        }
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override string GetStringRepresentation()
    {
        return $"{_name} - {_description} (Points: {_points}, Completed: {_amountCompleted}/{_target}, Bonus: {_bonus})";
    }

    public override string GetDetailsString()
    {
        string checkbox = IsComplete() ? "[X]" : "[ ]";
        return $"{checkbox} {_name} ({_description}) -- Currently completed: {_amountCompleted}/{_target}";
    }

    public override string Serialize()
    {
        return $"ChecklistGoal|{_name}|{_description}|{_points}|{_target}|{_bonus}|{_amountCompleted}";
    }

    public static ChecklistGoal DeserializeGoal(string[] parts)
    {
        string name = parts[1];
        string description = parts[2];
        int points = int.Parse(parts[3]);
        int target = int.Parse(parts[4]);
        int bonus = int.Parse(parts[5]);
        int amountCompleted = int.Parse(parts[6]);
        return new ChecklistGoal(name, description, points, target, bonus, amountCompleted);
    }

    public static ChecklistGoal Create()
    {
        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();

        Console.Write("Enter goal description: ");
        string description = Console.ReadLine();

        Console.Write("Enter points for this goal: ");
        int points;
        while (!int.TryParse(Console.ReadLine(), out points) || points < 0)
        {
            Console.Write("Please enter a valid number of points: ");
        }

        Console.Write("How many times does this goal need to be completed? ");
        int target;
        while (!int.TryParse(Console.ReadLine(), out target) || target <= 0)
        {
            Console.Write("Please enter a valid target number: ");
        }

        Console.Write("What is the bonus for completing this goal? ");
        int bonus;
        while (!int.TryParse(Console.ReadLine(), out bonus) || bonus < 0)
        {
            Console.Write("Please enter a valid bonus amount: ");
        }

        return new ChecklistGoal(name, description, points, target, bonus);
    }
}