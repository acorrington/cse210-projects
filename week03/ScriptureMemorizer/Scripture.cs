public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture()
    {
        _reference = new Reference("John", 3, 16);
        string text = "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.";
        _words = text.Split(' ').Select(w => new Word(w)).ToList();
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