public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public override int RecordEvent()
    {
        Console.WriteLine($"Congratulations! You earned {_points} points.");
        return _points;
    }

    public override bool IsComplete()
    {
        return false; 
    }

    public override string GetStringRepresentation()
    {
        return $"{_name} - {_description} (Points: {_points}) - This is an eternal goal and cannot be completed.";
    }

    public override string Serialize()
    {
        return $"EternalGoal|{_name}|{_description}|{_points}";
    }

    public static EternalGoal DeserializeGoal(string[] parts)
    {
        string name = parts[1];
        string description = parts[2];
        int points = int.Parse(parts[3]);
        return new EternalGoal(name, description, points);
    }

    public static EternalGoal Create()
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

        return new EternalGoal(name, description, points);
    }
}