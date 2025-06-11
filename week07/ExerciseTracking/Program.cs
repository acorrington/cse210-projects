using System;

class Program
{
    static void Main(string[] args)
    {
        Running run = new Running(DateTime.Now, 30, 3.5);
        Cycling cycle = new Cycling(DateTime.Now, 45, 12);
        Swimming swim = new Swimming(DateTime.Now, 60, 45);

        Console.Clear();
        Console.WriteLine(run.GetSummary());
        Console.WriteLine(cycle.GetSummary());
        Console.WriteLine(swim.GetSummary());
    }
}