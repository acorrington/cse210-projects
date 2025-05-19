using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        Console.WriteLine("Welcome to the Journal App!");

        while (true)
        {
            Console.WriteLine("1. Add Entry");
            Console.WriteLine("2. Display All Entries");
            Console.WriteLine("3. Save Entries to File");
            Console.WriteLine("4. Load Entries from File");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Entry entry = new Entry();
                    entry.date = DateTime.Now.ToString("yyyy-MM-dd");
                    entry.promptText = promptGenerator.GetRandomPrompt();
                    Console.WriteLine($"Prompt: {entry.promptText}");
                    Console.Write("Your entry: ");
                    entry.entryText = Console.ReadLine();
                    journal.AddEntry(entry);
                    break;

                case "2":
                    journal.DisplayAll();
                    break;

                case "3":
                    Console.Write("Enter filename to save journal entries: ");
                    string filename = Console.ReadLine();   
                    journal.SaveToFile(filename + ".json");
                    Console.WriteLine($"Entries saved to {filename}");
                    break;

                case "4":
                    Console.Write("Enter filename to load journal entries: ");
                    string loadFilename = Console.ReadLine();
                    journal.LoadFromFile(loadFilename + ".json");
                    Console.WriteLine($"Entries loaded from {loadFilename}");
                    break;

                case "5":
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}