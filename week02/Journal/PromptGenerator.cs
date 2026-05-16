using System;

public class PromptGenerator
{
    private string[] prompts = {
        "Who was the most interesting person I met today?",
        "What was the best part of my day?",
        "What emotion was the strongest I felt today?",
        "What would I do differently if I could repeat the day?",
        "How did I see the hand of the Lord in my life today?"
    };

    public string GetRandomPrompt()
    {
        Random rand = new Random();
        int index = rand.Next(prompts.Length);
        return prompts[index];
    }
}
