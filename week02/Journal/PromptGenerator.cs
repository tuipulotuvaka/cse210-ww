public class PromptGenerator
{
    public List<string> _prompts = new List<string>
    {
        "What was the best part of my day?",
        "What is something I learned today?",
        "Who was the most interesting person I interacted with today?",
        "What am I grateful for today?",
        "What is one goal I have for tomorrow?",
        "How did I see the hand of the Lord in my life today?",
        "What was something that made me smile today?"
    };

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
}