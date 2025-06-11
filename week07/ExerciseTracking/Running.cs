public class Running : Activity
{
    private double _distance;

    public Running(DateTime date, double duration, double distance) : base(date, duration, "Running")
    {
        _distance = distance;
    }

    public override string GetSummary()
    {
        double speed = _distance / _duration * 60;
        double pace = _duration / _distance; 
        return $"{base.GetSummary()} - Distance: {_distance:F1} miles, Speed: {speed:F1} mph, Pace: {pace:F1} min per mile";
    }
}