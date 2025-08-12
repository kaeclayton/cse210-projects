public class Swimming : Activity
{
    private int _laps;
    

    public Swimming(DateTime date, double minutes, int laps ) : base(date, minutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        double _distance = _laps * 50 / 1000;
        return _distance;
    }

    public override double GetSpeed()
    {
        double _speed = _laps * 20 / (_minutes * 60);
        return _speed;
    }

    public override double GetPace()
    {
        double _pace = _minutes / (_laps / 20);
        return _pace;
    }
}