public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
        _isComplete = false;
    }

    // Private constructor for deserialization
    private SimpleGoal(string name, string description, int points, bool isComplete)
        : base(name, description, points)
    {
        _isComplete = isComplete;
    }

    public override int RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
            Console.WriteLine($"Goal '{_name}' completed! You earned {_points} points.");
            return _points;
        }
        else
        {
            Console.WriteLine($"Goal '{_name}' is already completed.");
            return 0;
        }
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetStringRepresentation()
    {
        return $"{_name} - {_description} (Points: {_points}) - Completed: {_isComplete}";
    }

    public override string Serialize()
    {
        return $"SimpleGoal|{_name}|{_description}|{_points}|{_isComplete}";
    }

    public static SimpleGoal DeserializeGoal(string[] parts)
    {
        string name = parts[1];
        string description = parts[2];
        int points = int.Parse(parts[3]);
        bool isComplete = bool.Parse(parts[4]);
        return new SimpleGoal(name, description, points, isComplete);
    }

    public static SimpleGoal Create()
    {
        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();

        Console.Write("Enter goal description: ");
        string description = Console.ReadLine();

        Console.Write("Enter points for the goal: ");
        int points;
        while (!int.TryParse(Console.ReadLine(), out points) || points < 0)
        {
            Console.Write("Please enter a valid number of points: ");
        }

        return new SimpleGoal(name, description, points);
    }
}