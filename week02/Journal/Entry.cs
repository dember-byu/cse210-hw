//exceeding requirements

public class Entry
{
    public string Date { get; set; }
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Emotion { get; set; } // exceeding requirements

    public void Display()
    {
        Console.WriteLine($"{Date} - {Prompt}");
        Console.WriteLine(Response);
        if (!string.IsNullOrEmpty(Emotion))
        {
            Console.WriteLine($"Emotion: {Emotion}");
        }
        Console.WriteLine();
    }
}
