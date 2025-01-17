using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        
        int enteredNumber = -1;
        while (enteredNumber != 0)
        {
            Console.Write("Enter a new number, or enter 0 to quit:");
            
            string userResponse = Console.ReadLine();
            enteredNumber = int.Parse(userResponse);
            
            if (enteredNumber != 0)
            {
                numbers.Add(enteredNumber);
            }
        }

        int total = 0;
        foreach (int number in numbers)
        {
            total += number;
        }

        Console.WriteLine($"Your total is {total}");

        float average = ((float)total) / numbers.Count;
        Console.WriteLine($"Your average is {average}");
        
        int max = numbers[0];

        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }

        Console.WriteLine($"Your max is {max}");
    }
}