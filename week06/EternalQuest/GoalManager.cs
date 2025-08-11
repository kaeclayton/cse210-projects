public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        //Main menu program loop
        while (true)
        {
            Console.WriteLine($"\nYou have {_score} points.");
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Update Progress Goal");
            Console.WriteLine("7. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": CreateGoal(); break;
                case "2": ListGoalDetails(); break;
                case "3": SaveGoals(); break;
                case "4": LoadGoals(); break;
                case "5": RecordEvent(); break;
                case "6": UpdateProgressGoal(); break;
                case "7":
                    Console.WriteLine("Goodbye!");
                    return;
                default: Console.WriteLine("Invalid choice."); break;
            }
        }
    }

    public int GetLevel()
    {
        return _score / 1000;
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"Current Score: {_score}");
        Console.WriteLine($"Current Level: {GetLevel()}");
        if (_score % 1000 < 200 && _score > 0)
        {
            Console.WriteLine($"Only {1000 - (_score % 1000)} points until next level!");
        }
    }

    public void ListGoalNames()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].ShortName}");
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            string completion = _goals[i].IsComplete() ? "[X]" : "[ ]";
            Console.WriteLine($"{i + 1}. {completion} {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("1. Simple Goal (One-time)");
        Console.WriteLine("2. Eternal Goal (Repeating)");
        Console.WriteLine("3. Checklist Goal (Requires X completions)");
        Console.WriteLine("4. Progress Goal (Track incremental progress)");
        Console.Write("Which type of goal would you like to create? ");
        string type = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        switch (type)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case "3":
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
            case "4":
                Console.Write("Enter the target progress (e.g., 26.2 for a marathon): ");
                int targetProgress = int.Parse(Console.ReadLine());
                _goals.Add(new ProgressGoal(name, description, points, targetProgress));
                break;
            default:
                Console.WriteLine("Invalid goal type. Goal not created.");
                break;
        }

        Console.WriteLine("New goal added!");
    }

    public void RecordEvent()
    {
        ListGoalNames();
        Console.Write("Which goal did you accomplish? ");
        int goalNumber = int.Parse(Console.ReadLine()) - 1;

        if (goalNumber >= 0 && goalNumber < _goals.Count)
        {
            _goals[goalNumber].RecordEvent();
            _score += _goals[goalNumber].Points;
            Console.WriteLine($"Congratulations! You have earned {_goals[goalNumber].Points} points!");
        }
        else
        {
            Console.WriteLine("Invalid goal selection.");
        }
    }

    public void SaveGoals()
    {
        Console.Write("Enter the filename to save to: ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
    }

    public void LoadGoals()
    {
        Console.Write("Enter the filename to load from: ");
        string filename = Console.ReadLine();

        if (File.Exists(filename))
        {
            _goals.Clear();
            string[] lines = File.ReadAllLines(filename);
            _score = int.Parse(lines[0]);

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(':');
                string type = parts[0];
                string[] details = parts[1].Split(',');

                switch (type)
                {
                    case "SimpleGoal":
                        bool isComplete = bool.Parse(details[3]);
                        var simpleGoal = new SimpleGoal(details[0], details[1], int.Parse(details[2]));
                        if (isComplete) simpleGoal.RecordEvent();
                        _goals.Add(simpleGoal);
                        break;
                    case "EternalGoal":
                        _goals.Add(new EternalGoal(details[0], details[1], int.Parse(details[2])));
                        break;
                    case "ChecklistGoal":
                        var checklistGoal = new ChecklistGoal(
                            details[0], details[1],
                            int.Parse(details[2]),
                            int.Parse(details[4]),
                            int.Parse(details[3]));
                        checklistGoal.SetAmountCompleted(int.Parse(details[5]));
                        _goals.Add(checklistGoal);
                        break;
                    case "ProgressGoal":
                        var progressGoal = new ProgressGoal(
                            details[0], details[1],
                            int.Parse(details[2]),
                            int.Parse(details[3]));
                        progressGoal.SetCurrentProgress(int.Parse(details[4]));
                        _goals.Add(progressGoal);
                        break;
                }
            }
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }

    public void UpdateProgressGoal()
    {
        var progressGoals = _goals.OfType<ProgressGoal>().ToList();

        if (progressGoals.Count == 0)
        {
            Console.WriteLine("No progress goals found.");
            return;
        }

        Console.WriteLine("\nProgress Goals:");
        for (int i = 0; i < progressGoals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {progressGoals[i].GetDetailsString()}");
        }

        Console.Write("Select a progress goal to update: ");
        int selected = int.Parse(Console.ReadLine()) - 1;

        Console.Write("Enter progress to add (e.g., 5 for miles): ");
        int amount = int.Parse(Console.ReadLine());

        var goal = (ProgressGoal)progressGoals[selected];
        goal.AddProgress(amount);
        _score += goal.Points; //Award points per progress unit

        Console.WriteLine($"Updated! New progress: {goal.GetDetailsString()}");
        if (goal.IsComplete())
        {
            Console.WriteLine("Goal Complete!");
        }
    }
}