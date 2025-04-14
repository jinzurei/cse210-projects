public class Cycling : Activity
{
    private double _speed; // in mph

    public Cycling(string date, double minutes, double speed) : base(date, minutes)
    {
        _speed = speed;
    }

    public override double GetSpeed() => _speed;
    public override double GetDistance() => (_speed * GetMinutes()) / 60;
    public override double GetPace() => GetMinutes() / GetDistance();
}
