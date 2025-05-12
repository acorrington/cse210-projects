using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        
        int number = 0;
        List<int> numbers = new List<int>();
        do
        {
            Console.Write("Enter number: ");
            number = int.Parse(Console.ReadLine());
            if (number != 0)
            {
                numbers.Add(number);
            }            
        }
        while (number != 0);        


        Console.WriteLine($"The sum is: {numbers.Sum()}");
        Console.WriteLine($"The average is: {numbers.Average()}");
        Console.WriteLine($"The largest number is: {numbers.Max()}");

        Console.WriteLine($"The smallest positive number is: {numbers.Where(n => n > 0).DefaultIfEmpty(int.MaxValue).Min()}");

        Console.WriteLine("The sorted list is:");
        numbers.Sort();
        foreach (int n in numbers)
        {
            Console.WriteLine(n);
        }
    }
}