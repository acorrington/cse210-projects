using Newtonsoft.Json;

public class BreathingActivity : Activity
{
    private const string jsonFileName = "breathingActivity.json";
    private int _breathCount;

    public BreathingActivity() : base()
    {
        string json = LoadJSON(jsonFileName);
        dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
        
        _name = data.activity.name;
        _description = data.activity.description;
        _breathCount = 0;
    }

    public void Start()
    {
        DisplayStartingMessage();
 
        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            Console.Write("Breathe in...");
            ShowCountdown(4);
            Console.WriteLine();

            Console.Write("Hold your breath...");
            ShowCountdown(4);
            Console.WriteLine();

            Console.Clear();

            Console.Write("Breathe out...");
            ShowCountdown(4);
            Console.WriteLine();

            Console.Write("Hold your breath...");
            ShowCountdown(4);
            Console.WriteLine();
            
            Console.Clear();
            _breathCount++;
        }

        Console.WriteLine($"You completed {_breathCount} breaths.");
        DisplayEndingMessage();        
    }
}