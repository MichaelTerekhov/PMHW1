using System;
using System.Diagnostics;
using System.Threading;
namespace _2._4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("2.4 Hey, Bro!\n" +
                "If you want to try your luck in guessing the number that\n" +
                "the computer will guess in its own range,\n" +
                "then this program is for you.\n" +
                "(c)Michael Terekhov\n\n");
            Instructions();

            int rangeF;
            int rangeT;
            int num;
            Random rand = new Random();

            Console.WriteLine("\n\n\nPRESS ANY KEY TO START");
            Console.ReadKey();
            while (true)
            {
                Console.Write("Please enter range(FROM): ");
                var temp = Console.ReadLine();
                if (temp.ToLower() == "exit")
                {
                    Console.WriteLine("\nSee you next time!");
                    break;
                }

                if (!isNum(temp)) continue;
        
                Console.Write("Please enter range(TO): ");
                var temp2 = Console.ReadLine();
                if (temp2.ToLower() == "exit")
                {
                    Console.WriteLine("\nSee you next time!");
                    break;
                }

                if (!isNum(temp2)) continue;
                rangeF = int.Parse(temp);
                rangeT = int.Parse(temp2);

                num = rand.Next(rangeF, rangeT + 1);

                Console.WriteLine("Lets guess number!");
                Game(num, rangeF,rangeT);
                

            }
            Console.ReadKey();
        }
        static void Instructions()
        {
            Console.WriteLine("Before starting, let me explain\n" +
                "to you the rules of the game.\n\n" +
                "1. You enter a range of the computer tries to guess a number\n" +
                "( 0 <= RANGE <= 1 000 000)\n" +
                "2. You begin to guess the given hidden number.\n" +
                "And the computer tells you 'cold' or 'warm'\n" +
                "3. If you want to surrender / leave the game: Just enter EXIT\n" +
                "4. At the end of your game, you can see statistics for one game session\n\n" +
                "GOOD LUCK!");
        }
        static void Alert()
        {
            Console.WriteLine("\n\nOops, smth went wrong!!!\n" +
               "1. You enter a range of the computer tries to guess a number\n" +
               "\n!!!( 0 <= RANGE <= 1 000 000)!!!\n\n" +
               "2. You begin to guess the given hidden number.\n" +
               "And the computer tells you 'cold' or 'warm'\n" +
               "3. If you want to surrender / leave the game: Just enter EXIT\n" +
               "4. At the end of your game, you can see statistics for one game session\n\n");
        }
        static void NaN()
        {
            Console.WriteLine("\nBe careful!!!\n" +
                "You entered not NaN, or entered a number that does not fall\n" +
                "into the range");

        }

        static bool isNum(string s)
        {
            int checker;
            bool isNumCH = int.TryParse(s, out checker);
            if (!isNumCH || int.Parse(s) < 0 || int.Parse(s) > 1000000)
            {
                Alert();
                return false;
            }
            return true;
        }
        static bool isNum(string s, int Plug)
        {
            int checker;
            bool isNumCH = int.TryParse(s, out checker);
            if (!isNumCH || int.Parse(s) < 0 || int.Parse(s) > 1000000)
            {
                return false;
            }
            return true;
        }
        static void Congrat(int comp, int yourchoise, int RangeSum, int attempts, string time)
        {
            double n = 0;
            double temp = 0;
            for (var i =0d; i < short.MaxValue; i++)
            {
                temp = Convert.ToInt32(Math.Pow(Convert.ToDouble(2), Convert.ToDouble(i)));
                if (temp > Convert.ToDouble(RangeSum))
                {
                    n = i-1;
                    break;
                }
                if (temp == Convert.ToDouble(RangeSum))
                {
                    n = i;
                    break;
                }
            }
            double score = 100d * ((n - Convert.ToDouble(attempts))/n);
            if (score <= 0d) score = 1d;
            Console.WriteLine($"\nCongratulations!\n" +
                $"Your score is\t{Math.Round(score)}\n" +
                $"Total attempts\t{attempts}\n" +
                $"Your last choise was\t{yourchoise}\n" +
                $"Computer choise\t{comp}\n" +
                $"The game session lasted {time}\n" +
                $"Rangesum {RangeSum}");
        }
        static void Game(int ComputerGuess, int from, int to)
        {
            int Num;
            int attempts = 0;
            Stopwatch time = new Stopwatch();
            time.Start();
            while (true)
            {
                Console.Write("\nYour choise: ");
                var choise = Console.ReadLine();
                if (choise.ToLower() == "exit")
                {
                    time.Stop();
                    TimeSpan ts = time.Elapsed;
                    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    ts.Hours, ts.Minutes, ts.Seconds,
                    ts.Milliseconds / 10);
                    Console.WriteLine($"\nSee you next time!\n" +
                        $"Your score is\t{0}\n" +
                        $"Total attempts\t{attempts}\n" +
                        $"Computer choise\t{ComputerGuess}\n" +
                        $"The game session lasted {elapsedTime}\n" +
                        $"Rangesum {(to-from)+1}");
                    break;
                }
                if (!isNum(choise,0) || int.Parse(choise) < from || int.Parse(choise) > to)
                {
                    NaN();
                    continue;
                }
                Num = int.Parse(choise);
                if (ComputerGuess == Num)
                {
                    time.Stop();
                    TimeSpan ts = time.Elapsed;
                    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    ts.Hours, ts.Minutes, ts.Seconds,
                    ts.Milliseconds / 10);
                    Congrat(ComputerGuess,Num,(to - from)+1,attempts,elapsedTime);
                    break;
                }
                if (ComputerGuess != Num)
                {
                    if (ComputerGuess > Num)
                    {
                        Console.WriteLine($"Computer choise is more than {Num}");
                        attempts++;
                        continue;
                    }
                    else
                    {
                        Console.WriteLine($"Computer choise is less than {Num}");
                        attempts++;
                        continue;
                    }
                }

            }
        }
    }
}
