public class ReflectionActivity : Activity
{
    private const string jsonFileName = "reflectionActivity.json";
    private List<string> _prompts = new List<string>();
    private List<string> _questions = new List<string>();

    public ReflectionActivity() : base()
    {
        string json = LoadJSON(jsonFileName);
        dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject(json);

        _name = data.activity.name;
        _description = data.activity.description;
        _prompts = data.activity.prompts.ToObject<List<string>>();
        _questions = data.activity.questions.ToObject<List<string>>();
    }

    public void Start()
    {
        DisplayStartingMessage();

        DisplayPrompt();
        Console.Write("Take a moment to reflect...");
        
        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            DisplayQuestion();
        }

        Console.WriteLine("Finishing...");
        ShowCountdown(5);
        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }

    private string GetRandomQuestion()
    {
        Random random = new Random();
        int index = random.Next(_questions.Count);
        return _questions[index];
    }

    private void DisplayPrompt()
    {
        string prompt = GetRandomPrompt();
        Console.WriteLine(prompt);
        Console.Write("Take a moment to reflect on this prompt.");
        ShowSpinner(5);
        Console.WriteLine();
    }

    public void DisplayQuestion()
    {
        string question = GetRandomQuestion();
        Console.WriteLine(question);
        Console.Write("Take a moment to think about your answer.");
        ShowSpinner(5);
        Console.WriteLine();
    }
}