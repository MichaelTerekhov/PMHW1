using System;

namespace _1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1.2 Hey, Bro!\n" +
                "This program gives us the opportunity to calculate the chance\n" +
                "of winning or a draw with the entered odds for a certain outcome.\n" +
                "(c)Michael Terekhov");
            Console.WriteLine("Please write name of teams");
            Console.Write("Home team: "); 
            var t1 = Console.ReadLine();
            Console.Write("Guests team: ");
            var t2 = Console.ReadLine();
            Console.WriteLine();
            Console.Write($"Coefficient on {t1}: ");
            var coef1 = double.Parse(Console.ReadLine().Replace(".",","));
            Console.Write($"Coefficient on {t2}: ");
            var coef2 = double.Parse(Console.ReadLine().Replace(".", ","));
            Console.Write($"Coefficient on Draw: ");
            var Cdraw= double.Parse(Console.ReadLine().Replace(".", ","));
            SportsBook(t1, t2, coef1, coef2, Cdraw);
            Console.ReadKey();
        }
        static void SportsBook(string t1, string t2, double coef1, double coef2, double Cdraw)
        {
            var per1 = 1 / coef1;
            var per2 = 1 / coef2;
            var perdr = 1 / Cdraw;
            var mar = 1-(1/(per1 + per2 + perdr));
            var sum = per1 + per2 + perdr;
            Console.WriteLine($"Chance to win for {t1} is {Math.Round((per1/sum )*100,1)}%");
            Console.WriteLine($"Chance to win for {t2} is {Math.Round((per2/sum )*100,1)}%");
            Console.WriteLine($"Chance to Draw is {Math.Round((perdr/sum ) *100,1)}%");
            Console.WriteLine($"Margin is {Math.Round(mar * 100,1)}%");
        }
    }
}
