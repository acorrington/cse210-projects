public class Entry
{
    public string date { get; set; }
    public string promptText { get; set; }
    public string entryText { get; set; }


    public Entry()
    {
        date = string.Empty;
        promptText = string.Empty;
        entryText = string.Empty;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {date}");
        Console.WriteLine($"Prompt: {promptText}");
        Console.WriteLine($"Entry: {entryText}");
        Console.WriteLine();
    }
}