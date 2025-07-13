public class PromptGenerator
{
    public List<string> _prompts = new List<string>
    {
        "What was the highlight of my day?",
        "Who was the most interesting person I interacted with today?",
        "What am I grateful for today?",
        "If I had one thing I could do over today, what would it be?",
        "What was a tender mercy I saw today?",
        "How did I see the hand of the Lord today?",
        "What was the strongest emotion I felt today?",
        "What was a challenge I faced today? How did I handle it?",
        "If today had a theme song, what would it be?",
        "What is something I've learned recently?",
        "What prompting did I follow?",
        "Write about a place to feel peace.",
        "What is a goal I am working on?"
    };

    private Random random = new Random();
    public string GetRandomPrompt()
    {
        string randomPrompt = _prompts[random.Next(_prompts.Count)];
        return randomPrompt;
    }
}