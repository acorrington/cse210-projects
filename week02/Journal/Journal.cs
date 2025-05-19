using System.Text.Json;

public class Journal
{
    private List<Entry> _entries;

    public Journal()
    {
        _entries = new List<Entry>();
    }

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        JsonSerializerOptions _jsonOptions = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(_entries, _jsonOptions);
        File.WriteAllText(filename, json);
    }

    public void LoadFromFile(string filename)
    {
        if (File.Exists(filename))
        {
            string json = File.ReadAllText(filename);
            List<Entry> loadedEntries = JsonSerializer.Deserialize<List<Entry>>(json);
            if (loadedEntries != null)
            {
                _entries = loadedEntries;
            }
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}