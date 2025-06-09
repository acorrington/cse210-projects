using System.Reflection;

public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity()
    {
        _name = string.Empty;
        _description = string.Empty;
        _duration = 0;
    }

    protected string LoadJSON(string jsonFileName)
    {
        string sourceDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location )+ "\\json\\";
        string filePath = Path.Combine(sourceDirectory, jsonFileName);

        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"The file {filePath} does not exist.");
        }

        try
        {
            return File.ReadAllText(filePath);

        }
        catch (Exception ex)
        {
            throw new Exception($"Error reading the file {filePath}: {ex.Message}");
        }
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name} activity.");
        Console.WriteLine(_description);
        Console.Write($"How many seconds should this activity will last for? ");
        _duration = Convert.ToInt32(Console.ReadLine());
        Console.Write("Get ready...");
        ShowSpinner(5);
        Console.Clear();
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("Well done!");
        Console.WriteLine($"You completed the {_name} activity.");
        ShowSpinner(4);
        Console.Clear();
    }

    public void ShowSpinner(int seconds)
    {
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        while (DateTime.Now < endTime)
        {
            Console.Write("/");
            Thread.Sleep(250);
            Console.Write("\b \b");
            Console.Write("\\");
            Thread.Sleep(250);
            Console.Write("\b \b");
        }
        Console.WriteLine();
    }

    public void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}