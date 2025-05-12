using System;

class Program
{
    static void Main(string[] args)
    {
        // Call the DisplayMessage method
        DisplayMessage();

        // Call the GetName method and store the result in a variable
        string name = GetName();

        // Call the GetNumber method and store the result in a variable
        int number = GetNumber();

        // Call the SquareNumber method and store the result in a variable
        int squaredNumber = SquareNumber(number);

        // Call the DisplayResult method with the name and squared number
        DisplayResult(name, squaredNumber);
    }

    static void DisplayMessage()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    static string GetName()
    {
        Console.Write("What is your name? ");
        string name = Console.ReadLine();
        return name;
    }

    static int GetNumber()
    {
        Console.Write("What is your favorite number? ");
        int number = int.Parse(Console.ReadLine());
        return number;
    }

    static int SquareNumber (int number)
    {
        return number * number;
    }

    static void DisplayResult(string name, int squaredNumber)
    {
        Console.WriteLine($"Hello {name}, your favorite number squared is {squaredNumber}.");
    }
}