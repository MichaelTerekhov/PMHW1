using System;

namespace _1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            const double b = 2002;
            const  double c = 10;
            const double d = 14;
            Console.WriteLine("1.1 Hey, Bro!\n" +
                "This is programm for simple calculation of unusual function\n" +
                "This programm uses standart arithmetic operators, Math that provides constants and static methods for\n" +
                "trigonometric, logarithmic, and other common mathematical functions\n" +
                "(c)Michael Terekhov");
            Console.WriteLine("y = ((exp^a + (4* lg(c)))/(sqrt(b)) * mod(arctg(d))) + 5/(sin(a))\n");
            Console.Write("Would you like to calculate?\nPlease enter param\na(any integer which would you like)\n" +
                "(double by comma(,) separator)\n" +
                "a = ");
            var a = Console.ReadLine().Replace(".", ",");
            Console.WriteLine($"Your input:\na={a}\nb={b}(birth year of dev)\nc={c}(birth month of dev)\nd={d}(birth day of dev)");
            var y = ((Math.Pow(Math.E, double.Parse(a)) + (4 * Math.Log10(c))) / (Math.Sqrt(b)) * Math.Abs(Math.Atan(d))) + 5 / (Math.Sin(double.Parse(a)));
            Console.WriteLine($"RESULT OF CALCULATION IS {y}\n");
            while (true)
            {
                Console.Write("Lets continue!!!?\nPlease enter param\n(IF YOU WOULD LIKE TO EXIT WRITE EXIT)\na(any integer which would you like)\n" +
                "(double by comma(,) separator)\n" +
                "a = ");
                a = Console.ReadLine().Replace(".", ",");
                Console.Write($"Your input:\na={a}\nb={b}(birth year of dev)\nc={c}(birth month of dev)\nd={d}(birth day of dev)\n");
                if (a.ToLower() == "exit")
                {
                    Console.WriteLine("\nSee you next time! Bye");
                    break;
                }
                y = ((Math.Pow(Math.E, double.Parse(a)) + (4 * Math.Log10(c))) / (Math.Sqrt(b)) * Math.Abs(Math.Atan(d))) + 5 / (Math.Sin(double.Parse(a)));
                Console.WriteLine($"RESULT OF CALCULATION IS {y}");
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
