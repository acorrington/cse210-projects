public class Swimming : Activity
{
    private double _laps;

    public Swimming(DateTime date, double duration, double laps) : base(date, duration, "Swimming")
    {
        _laps = laps;
    }

    public override string GetSummary()
    {
        double distance = _laps * 0.025; 
        double speed = distance / _duration * 60; 
        double pace = _duration / distance; 
        return $"{base.GetSummary()} - Distance: {distance:F1} miles, Speed: {speed:F1} mph, Pace: {pace:F1} min per mile";
    }
}