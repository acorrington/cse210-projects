using System;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        int gradePercent = int.Parse(Console.ReadLine());

        string gradeLetter;
        bool passed;
        string gradeModifier = string.Empty;

        if (gradePercent >= 90)
        {
            gradeLetter = "A";
            passed = true;
        }
        else if (gradePercent >= 80)
        {
            gradeLetter = "B";
            passed = true;
        }
        else if (gradePercent >= 70)
        {
            gradeLetter = "C";
            passed = true;
        }
        else if (gradePercent >= 60)
        {
            gradeLetter = "D";
            passed = false;
        }
        else
        {
            gradeLetter = "F";
            passed = false;
        }

        if (gradeLetter != "F")
        {
            int remainder = gradePercent % 10;            
            if (gradeLetter != "A")
            {
                if (remainder >= 7)
                {
                    gradeModifier = "+";
                }
            }
            
            if (remainder <= 3)
            {
                gradeModifier = "-";
            }
        }

        Console.WriteLine($"Your grade letter is {gradeLetter}{gradeModifier}.");
        if (passed)
        {
            Console.WriteLine("Congratulations! You passed the course!");
        }
        else
        {
            Console.WriteLine("You didn't pass the course. Better luck next time.");
        }  
    }
}