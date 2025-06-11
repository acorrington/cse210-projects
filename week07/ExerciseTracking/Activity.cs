public class Activity
{
    protected DateTime _date;
    protected double _duration;
    protected string _type;

    public Activity(DateTime date, double duration, string type)
    {
        _date = date;
        _duration = duration;
        _type = type;
    }

    public virtual string GetSummary()
    {
        return $"{_date.ToShortDateString()} {_type} ({_duration} min)";
    }
}