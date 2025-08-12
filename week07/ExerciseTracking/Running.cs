public class Running : Activity
{
    private double _distance;

    public Running(DateTime date, double minutes, double distance) : base(date, minutes)
    {
        _distance = distance;
    }

    public override double GetDistance()
    {
        return _distance;
    }

    public override double GetSpeed()
    {
        double _speed = _distance / _minutes * 60;
        return _speed;
    }

    public override double GetPace()
    {
        double _pace = _minutes / _distance;
        return _pace;
    }
}
