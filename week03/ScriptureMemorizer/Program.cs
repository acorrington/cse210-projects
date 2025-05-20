using System;

class Program
{
    static void Main(string[] args)
    {
        Scripture scripture = new Scripture();
        while (scripture.IsCompletelyHidden() == false)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide more words or type 'exit' to quit.");
            string input = Console.ReadLine();
            if (input.ToLower() == "exit")
            {
                break;
            }
            scripture.HideRandomWords(3);
        }

        if (scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
        }
    }
}