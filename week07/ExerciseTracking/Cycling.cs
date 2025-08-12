public class Cycling : Activity
{
    private double _speed;
    

    public Cycling(DateTime date, double minutes, double speed) : base(date, minutes)
    {
        _speed = speed;
    }

    public override double GetDistance()
    {
        double _distance = _speed * _minutes / 60;
        return _distance;
    }

    public override double GetSpeed()
    {
        return _speed;
    }

    public override double GetPace()
    {
        double _pace = 60 / _speed;
        return _pace;
    }
}