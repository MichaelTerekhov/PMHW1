using System;

namespace _1._3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1.3 Hey, Bro!\n" +
                "I am glad to present to you a very interesting calculation of the mathematical series\n" +
                "Name of the mathematical series:  SIGMA(i=1; i ->oo) = 1 / (i*(i+1))\n" +
                "(c)Michael Terekhov");
            const double year = 2002 ;
            const double eps = 1 / year;
            Console.WriteLine($"ATTENTION!!!\n\nThe calculation of the sum will be performed until the element is less than epsilon\n" +
                $"EPSILON = 1 / programmers birth year\tEPSILON = {eps}\n" +
                $"Current birth year is {year}");
            var sum = 0d;
            for (double i = 1; i < int.MaxValue; i++)
            {
                double elem = 1 / (i * (i + 1));
                if (elem < eps)
                {
                    sum += elem;
                    Console.WriteLine($"Last elem integrated in sum is {elem}");
                    break;
                }
                sum += elem;
            }
            Console.WriteLine($"Result of calculation: {sum}");
            Console.ReadKey();
        }
    }
}
