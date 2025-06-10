public abstract class Goal
{
    protected string _name;
    protected string _description;
    protected int _points;

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    public abstract int RecordEvent();
    public abstract bool IsComplete();
    public abstract string GetStringRepresentation();

    public string GetName()
    {
        return _name;
    }

    public virtual string GetDetailsString()
    {
        string checkbox = IsComplete() ? "[X]" : "[ ]";
        return $"{checkbox} {_name} ({_description})";
    }

    // Abstract method for serialization
    public abstract string Serialize();
    
    // Static method to deserialize goals from string
    public static Goal Deserialize(string data)
    {
        string[] parts = data.Split('|');
        string goalType = parts[0];
        
        switch (goalType)
        {
            case "SimpleGoal":
                return SimpleGoal.DeserializeGoal(parts);
            case "EternalGoal":
                return EternalGoal.DeserializeGoal(parts);
            case "ChecklistGoal":
                return ChecklistGoal.DeserializeGoal(parts);
            default:
                throw new ArgumentException($"Unknown goal type: {goalType}");
        }
    }
}