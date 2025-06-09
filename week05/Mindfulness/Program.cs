using System;
/// <summary>
/// Showing Creativity and Exceeding Requirements: I have the program read from a json file to load the activity details.
/// </summary>
class Program
{
    static void Main(string[] args)
    {
        Activity activity = new Activity();

        int choice = 0;
        while (choice != 4)
        {
            ShowMenu();
            string input = Console.ReadLine();
            if (int.TryParse(input, out choice))
            {
                switch (choice)
                {
                    case 1:
                        BreathingActivity breathingActivity = new BreathingActivity();
                        breathingActivity.Start();
                        break;
                    case 2:
                        ReflectionActivity reflectionActivity = new ReflectionActivity();
                        reflectionActivity.Start();
                        break;
                    case 3:
                        ListingActivity listingActivity = new ListingActivity();
                        listingActivity.Start();
                        break;
                    case 4:
                        Console.WriteLine("Exiting the Mindfulness App. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid number.");
            }
        }
    }
    
    private static void ShowMenu()
    {
        Console.Clear();
        Console.WriteLine("Welcome to the Mindfulness App!");
        Console.WriteLine("1. Breathing Activity");
        Console.WriteLine("2. Reflecting Activity");
        Console.WriteLine("3. Listing Activity");
        Console.WriteLine("4. Exit");
        Console.Write("Please select an option: ");
    }
}