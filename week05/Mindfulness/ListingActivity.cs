public class ListingActivity : Activity
{
    private const string jsonFileName = "listingActivity.json";
    private List<string> _prompts;
    private List<string> _items;

    public ListingActivity() : base()
    {
        string json = LoadJSON(jsonFileName);
        dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject(json);

        _name = data.activity.name;
        _description = data.activity.description;
        _prompts = data.activity.prompts.ToObject<List<string>>();
        _items = new List<string>();
    }

    public void Start()
    {
        DisplayStartingMessage();
        DisplayPrompt();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {            
            string item = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(item))
            {
                _items.Add(item);
            }
            else
            {
                Console.WriteLine("Input cannot be empty. Please try again.");
            }
        }

        ShowCountdown(5);
        Console.WriteLine($"You listed {_items.Count} items.");
        DisplayEndingMessage();        
    }

    private string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }

    private void DisplayPrompt()
    {
        string prompt = GetRandomPrompt();
        Console.WriteLine(prompt);
        Console.Write("Take a moment to reflect on this prompt. Enter items as you think of them.");
        ShowCountdown(5);
        Console.WriteLine();
    }

    public List<string> GetListFromUser()
    {
        return _items;
    }
}