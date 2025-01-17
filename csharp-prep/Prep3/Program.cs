using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int secretNumber = randomGenerator.Next(1, 50);

        int guess = -1;

        while (guess != secretNumber)
        {
            Console.Write("Enter your guess: ");
            guess = int.Parse(Console.ReadLine());

            if (secretNumber > guess)
            {
                Console.WriteLine("Too Low");
            }
            else if (secretNumber < guess)
            {
                Console.WriteLine("Too High");
            }
            else
            {
                Console.WriteLine("Correct");
            }

        }                    
    }
}