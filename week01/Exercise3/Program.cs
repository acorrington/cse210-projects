using System;

class Program
{
    static void Main(string[] args)
    {
        string playAgain = "no";
        do
        {
            Console.WriteLine("Calculating the magic number...");

            Random rnd = new Random();
            int number = rnd.Next(1, 100);

            bool correctGuess = false;
            int numGuesses = 0;
            while (correctGuess == false)
            {
                Console.Write("What is your guess? ");
                int guess = int.Parse(Console.ReadLine());
                numGuesses++;

                if (guess == number)
                {
                    correctGuess = true;
                    Console.WriteLine("You guessed it!");
                    Console.WriteLine($"It took {numGuesses} guesses.");

                    Console.Write("Do you want to play again? ");
                    playAgain = Console.ReadLine();
                }
                else if (guess < number)
                {
                    Console.WriteLine("Higher");
                }
                else
                {
                    Console.WriteLine("Lower");
                }
            }
        }
        while (playAgain == "yes");
    }
}