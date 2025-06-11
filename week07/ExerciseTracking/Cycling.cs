public class Cycling : Activity
{
    private double _speed;

    public Cycling(DateTime date, double duration, double speed) : base(date, duration, "Cycling")
    {
        _speed = speed;
    }

    public override string GetSummary()
    {
        double distance = _speed * _duration / 60;
        double pace = _duration / distance;
        return $"{base.GetSummary()} - Distance: {distance:F1} miles, Speed: {_speed:F1} mph, Pace: {pace:F1} min per mile";
    }
}
