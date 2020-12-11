using System;

namespace _1._4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1.4 Hey, Bro!\n" +
                "This program was created to find prime numbers\n" +
                "in a range selected by the user.");
            Console.WriteLine("\nIf you would like to find prime number, please, enter grade\n" +
                "(IF you would like to exit : WRITE EXIT in from or to)\n");
            while (true)
            {
                Console.Write("From: ");
                var low = Console.ReadLine();
                Console.Write("To: ");
                var high = Console.ReadLine();
                if (low.ToLower() == "exit" || high.ToLower() == "exit") break;
                FindPrime(low, high);
            }
            Console.WriteLine("See you next time, BRO!");
            Console.ReadKey();
        }

        private static void FindPrime(string low, string high)
        {
            for (var i = int.Parse(low); i <= int.Parse(high); i++)
            {
                var isPrime = true;
                for (var j = 2; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (!isPrime) continue;

                Console.WriteLine($"Prime number {i} is in grade from {int.Parse(low)} to {int.Parse(high)}");
            }
            Console.WriteLine("(IF you would like to exit : WRITE EXIT in from or to)");
            Console.WriteLine();
        }
    }
}
