using System;

namespace _2._3
{
    class Program
    {
        static int Main(string[] args)
        {
            if (args.Length > 0)
            {
                for (var i = 0; i < args.Length; i++)
                {
                    string[] income = args[i].Replace(".", ",").Split(new char[] { ' ' });
                    double checker;
                    for (var m = 0; m < income.Length; m++)
                    {
                        bool isNum = double.TryParse(income[m].Replace(".", ","), out checker);
                        if (!isNum) return -1;
                    }
                    double[] Data = Array.ConvertAll<string, double>(income, Double.Parse);
                    for (var l = 0; l < income.Length; l++)
                    {
                        Data[l] = double.Parse(income[l].Replace(".", ","));
                    }
                    ScriptStat(Data);
                    Console.WriteLine(  );
                }
            }
            if (args.Length == 0)
            {
                Console.WriteLine("2.3 Hey, Bro!\n" +
                    "Welcome to the digital version of this app.\n" +
                    "Yo can easily see statistics about your Array\n" +
                    "\nJust enter Array Length\n" +
                    "\nAnd then enter each element\n" +
                    "If you need to exit: Write EXIT in array length" +
                    "(c)Michael Terekhov\n");
                int Length;
                while (true)
                {
                    Console.Write("\nPlease, enter array length: ");
                    var temp = Console.ReadLine();
                    if (temp.ToLower() == "exit")
                    {
                        Console.WriteLine("\nSee you next time!");
                        break;
                    }
                    bool isNum = int.TryParse(temp, out Length);
                    if (!isNum || int.Parse(temp) <= 0)
                    {
                        Console.WriteLine("Oops smth went wrong! Try again");
                        continue;
                    }
                        Length = int.Parse(temp);
                        double[] Data = new double[Length];
                        int i = 0;
                        while (i < Length)
                        {
                            Console.Write($"Please, enter Arr[{i}] = ");
                            var t = Console.ReadLine().Replace(".", ",");
                            bool isArrNum = double.TryParse(t, out Data[i]);
                            if (!isArrNum)
                            {
                                Console.WriteLine("Oops smth went wrong! Try again");
                                continue;
                            }
                                Console.WriteLine();
                                i++;
                        }
                    Console.Write("Array:\t");
                    for (int j = 0; j < Data.Length; j++)
                    {
                       
                        Console.Write(Data[j] + "  ");
                    }
                    Console.WriteLine();
                    Statistic(Data);
                    Console.Write("Sorted array:\t");
                    foreach (var m in InSort(Data))
                    {
                        Console.Write($"{m}  ");
                    }
                }
            }
            Console.ReadKey();
            return 0;
        }
        static void ScriptStat(double[] Data)
        {
            for(var i =0; i < Data.Length; i++ ) Console.Write(Data[i] + "  ");
            Console.WriteLine();
            double Min = Data[0];
            double Max = Data[0];
            double sum = 0;
            for (var i = 0; i < Data.Length; i++)
            {
                sum += Data[i];
                if (Min > Data[i]) Min = Data[i];
                if (Max < Data[i]) Max = Data[i];
            }
            double mean = sum / Convert.ToDouble((Data.Length));
            var temp = 0d;
            var Sigm = 0d;
            for (var i = 0; i < Data.Length; i++)
            {
                temp += Math.Pow(Data[i] - mean, 2);
                Sigm = Math.Sqrt(temp / Convert.ToDouble(Data.Length));
            }
            Console.WriteLine($"{Min}\n" +
                $"{Max}\n" +
                $"{sum}\n" +
               $"{mean}\n" +
               $"{Sigm}\n");
            foreach (var m in InSort(Data))
            {
                Console.Write($"{m}  ");
            }
        }
        static void Statistic(double[] Data)
        {
            double Min = Data[0];
            double Max = Data[0];
            double sum = 0;
            for (var i = 0; i < Data.Length; i++)
            {
                sum += Data[i];
                if (Min > Data[i]) Min = Data[i];
                if (Max < Data[i]) Max = Data[i];
            }
            double mean = sum / Convert.ToDouble((Data.Length));
            var temp = 0d;
            var Sigm = 0d;
            for (var i = 0; i < Data.Length; i++)
            {
                temp += Math.Pow(Data[i] - mean, 2);
                Sigm = Math.Sqrt(temp / Convert.ToDouble(Data.Length));
            }
            Console.WriteLine($"\nMin elem in array is {Min}\n" +
                $"Max elem in array is {Max}\n" +
                $"\nSum of all elements is {sum}\n" +
               $"Arithmetic mean is {mean}\n" +
               $"Root mean square deviation is {Sigm}\n");
        }
        static void Swap(ref double e1, ref double e2)
        {
            var temp = e1;
            e1 = e2;
            e2 = temp;
        }
        static double[] InSort(double[] Data)
        {
            for (var i = 0; i < Data.Length; i++)
            {
                var key = Data[i];
                int j = i;
                while ((j > 0) && (Data[j - 1] > key))
                {
                    Swap(ref Data[j - 1], ref Data[j]);
                    j--;
                }
                Data[j] = key;
            }
            return Data;
        }

    }
}
