public abstract class Goal
{
    protected string _shortName;
    protected string _description;
    protected int _points;

    protected Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    public string GetShortName() { return _shortName; }
    public string GetDescription() { return _description; }
    public int GetPoints() { return _points; }

    public abstract int RecordEvent();

    public abstract bool IsComplete();

    public virtual string GetDetailsString()
    {
        string checkbox = IsComplete() ? "[X]" : "[ ]";
        return $"{checkbox} {_shortName} ({_description})";
    }

    public abstract string GetStringRepresentation();
}