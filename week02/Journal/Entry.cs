public class Entry
{
    public string _date { get; set; }
    public string _promptText { get; set; }
    public string _entryText { get; set; }


    public Entry()
    {
        _date = string.Empty;
        _promptText = string.Empty;
        _entryText = string.Empty;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_promptText}");
        Console.WriteLine($"Entry: {_entryText}");
        Console.WriteLine();
    }
}