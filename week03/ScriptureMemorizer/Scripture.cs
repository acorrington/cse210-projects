using System.Text.Json;
using System.Reflection;
using System.IO;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture()
    {
        string binDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        string jsonFilePath = Path.Combine(binDirectory, "scriptures.json");

        if (File.Exists(jsonFilePath))
        {
            string json = File.ReadAllText(jsonFilePath);
            var scriptureDataList = JsonSerializer.Deserialize<List<ScriptureData>>(json);

            Random random = new Random();
            var selectedScripture = scriptureDataList[random.Next(scriptureDataList.Count)];

            _reference = new Reference(
                selectedScripture.Reference.Book,
                selectedScripture.Reference.Chapter,
                selectedScripture.Reference.Verse,
                selectedScripture.Reference.VerseEnd
            );
            _words = selectedScripture.Text.Split(' ').Select(w => new Word(w)).ToList();
        }
        else
        {
            // Fallback to default scripture if file doesn't exist
            _reference = new Reference("John", 3, 16);
            string text = "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.";
            _words = text.Split(' ').Select(w => new Word(w)).ToList();
        }
    }

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(w => new Word(w)).ToList();
    }

    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();
        int wordsHidden = 0;

        if (numberToHide > _words.Count)
        {
            numberToHide = _words.Count;
        }

        numberToHide = _words.Count(w => !w.IsHidden()) < numberToHide ? _words.Count(w => !w.IsHidden()) : numberToHide;

        while (wordsHidden < numberToHide)
        {
            int index = random.Next(_words.Count);
            if (!_words[index].IsHidden())
            {
                _words[index].Hide();
                wordsHidden++;
            }
        }
    }

    public string GetDisplayText()
    {
        string displayText = _reference.GetDisplayText() + " ";
        foreach (Word word in _words)
        {
            displayText += word.GetDisplayText() + " ";
        }
        return displayText.Trim();
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(w => w.IsHidden());
    }
}