public class ProgressGoal : Goal
{
    private int _currentProgress;
    private int _targetProgress;

    public int CurrentProgress { get => _currentProgress; private set => _currentProgress = value; }
    public int TargetProgress { get => _targetProgress; }

    public ProgressGoal(string name, string description, int points, int targetProgress)
        : base(name, description, points)
    {
        _currentProgress = 0;
        _targetProgress = targetProgress;
    }

    // Add progress (e.g., "Ran 5 miles today")
    public void AddProgress(int amount)
    {
        _currentProgress += amount;
    }

    public override void RecordEvent()
    {
        // Optional: Auto-complete when target is reached
        if (_currentProgress >= _targetProgress && !IsComplete())
        {
            _currentProgress = _targetProgress; // Cap progress
        }
    }

    public override bool IsComplete()
    {
        return _currentProgress >= _targetProgress;
    }

    public override string GetDetailsString()
    {
        return $"{base.GetDetailsString()} — Progress: {_currentProgress}/{_targetProgress}";
    }

    public override string GetStringRepresentation()
    {
        return $"ProgressGoal:{_shortName},{_description},{_points},{_targetProgress},{_currentProgress}";
    }

    public void SetCurrentProgress(int progress)
    {
        _currentProgress = progress;
    }
}