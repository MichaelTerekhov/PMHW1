using System;

namespace _2._2
{
    class Program
    {
        static int Main(string[] args)
        {
            if (args.Length > 0)
            {
                for (var step = 0; step < args.Length; step++)
                {
                    string[] income = args[step].Replace(".",",").Split(new char[] { ' ' });

                    if (income[0].ToLower() == "circle" && income.Length == 2)
                    {
                        double Rad;
                        bool isNum = double.TryParse(income[1], out Rad);
                        if (!isNum) return -1;
                        if (isNum)
                        {
                            if (Rad <= 0 || Rad >= int.MaxValue) return -1;
                            var Area = Math.PI * Math.Pow(Rad, 2);
                            Console.WriteLine(Area);
                        }
                    }
                    if (income[0].ToLower() == "square" && income.Length == 2)
                    {
                        double SideA;
                        bool isNum = double.TryParse(income[1], out SideA);
                        if (!isNum) return -1;
                        if (isNum)
                        {
                            if (SideA <= 0 || SideA >= int.MaxValue) return -1;
                            var Area = Math.Pow(SideA, 2);
                            Console.WriteLine(Area);
                        }
                    }

                    if (income[0].ToLower() == "rect" && income.Length == 3)
                    {
                        double SideA;
                        double SideB;
                        bool isNum = double.TryParse(income[1], out SideA);
                        bool isNum2 = double.TryParse(income[2], out SideB);
                        if (!isNum || !isNum2) ;//return -1;
                        if (isNum && isNum2)
                        {
                            if (SideA <= 0 || SideA >= int.MaxValue) ;//return -1;
                            if (SideB <= 0 || SideB >= int.MaxValue) ;//return -1;
                            var Area = SideA * SideB;
                            Console.WriteLine(Area);
                        }
                    }

                    if (income[0].ToLower() == "triangle" && income.Length == 4)
                    {
                        double SideA;
                        double SideB;
                        double SideC;

                        bool isNum = double.TryParse(income[1], out SideA);
                        bool isNum2 = double.TryParse(income[2], out SideB);
                        bool isNum3 = double.TryParse(income[3], out SideC);

                        if (!isNum || !isNum2 || !isNum3) return -1;
                        if (isNum && isNum2 && isNum3)
                        {
                            if (SideA <= 0 || SideA >= int.MaxValue) return -1;
                            if (SideB <= 0 || SideB >= int.MaxValue) return -1;
                            if (SideC <= 0 || SideC >= int.MaxValue) return -1;
                            if (SideA + SideB > SideC)
                            {
                                if (SideA + SideC > SideB)
                                {
                                    if (SideB + SideC > SideA)
                                    {
                                        var p = (SideA + SideB + SideC) / 2;
                                        var Area = Math.Sqrt(p * (p - SideA) * (p - SideB) * (p - SideC));
                                        Console.WriteLine(Area);
                                    }
                                    else return -1;
                                }
                                else return -1;
                            }
                            else return -1;
                        }
                    }
                    if (income[0].ToLower() != "circle" && income[0].ToLower() != "triangle" && income[0].ToLower() != "square" && income[0].ToLower() != "rect")
                    {
                        return -1;
                    }
                    Console.WriteLine();
                }
            }
            if (args.Length == 0)
            {
                Console.WriteLine("2.2 Hey bro!\n" +
                    "Welcome to the digital version of this app.\n" +
                    "With these commands you can calculate the area of ​​the figures!\n" +
                    "(c)Michael Terekhov\n");
                Instructions();

                string fig;

                Console.WriteLine("\nLETS START!\tPress any key!\n");
                Console.ReadKey();
                while (true)
                {
                    Console.Write("\nPlease enter name of the figure: ");
                    fig = Console.ReadLine().ToLower();
                    if (fig != "square" && fig != "rect" && fig != "circle" && fig != "exit" && fig != "triangle")
                    {
                        Alert();
                        continue;
                    }
                    if (fig == "exit")
                    {
                        Console.WriteLine("\nSee you next time!");
                        break;
                    }
                    if (fig == "square")
                    {
                        SquareArea();
                        continue;
                    }
                    if (fig == "circle")
                    {
                        CircleArea();
                        continue;
                    }
                    if (fig == "rect")
                    {
                        RectArea();
                        continue;
                    }
                    if (fig == "triangle")
                    {
                        TriangleArea();
                        continue;
                    }
                }
            }
            Console.ReadKey();
            return 0;
        }

        static void Instructions()
        {
            Console.WriteLine("Instruction:\n" +
                "1. Enter 'circle' and required params(R)\tTo calculate circles area\n" +
                "2. Enter 'triangle' and required params(A B C)\tTo calculate triangles area\n" +
                "\nBut be carefull : The sum of any two sides must be more than thirds!!!\n\n" +
                "3. Enter 'rect' and required params(A B)\tTo calculate rects area\n" +
                "4. Enter 'square' and required params(A)\tTo calculate squares area\n" +
                "5. Enter 'exit' if you would like to exit this programm\n\n" +
                "YOU can enter name of figures in any register");     
        }
        static void Alert()
        {
            Console.WriteLine("\nOops smth went wrong:\n" +
                "1. Enter 'circle' and required params(R)\tTo calculate circles area\n" +
                "2. Enter 'triangle' and required params(A B C)\tTo calculate triangles area\n" +
                "\nBut be carefull : The sum of any two sides must be more than thirds!!!\n\n" +
                "3. Enter 'rect' and required params(A B)\tTo calculate rects area\n" +
                "4. Enter 'square' and required params(A)\tTo calculate squares area\n" +
                "5. Enter 'exit' if you would like to exit this programm\n\n" +
                "YOU can enter name of figures in any register");
        }

        static void CircleArea()
        {
            Console.Write("\nPlease enter Radius:");
            try
            {
                string str = Console.ReadLine().Replace(".", ",");
                double Rad;
                bool isNum =  double.TryParse(str,out Rad);
                if (!isNum) throw new ArgumentException(nameof(str));
                if (isNum)
                {
                    if (Rad <= 0 || Rad >= int.MaxValue) throw new ArgumentException(nameof(Rad));
                    var Area = Math.PI * Math.Pow(Rad, 2);
                    Console.WriteLine($"Area of this circle with Radius = {Rad}  S=\t{Area}");
                }
            }
            catch(ArgumentException)
            {
                Alert();
            }
        }
        static void SquareArea()
        {
            Console.Write("\nPlease enter Side of your square:");
            try
            {
                string str = Console.ReadLine().Replace(".", ",");
                double Side;
                bool isNum = double.TryParse(str, out Side);
                if (!isNum) throw new ArgumentException(nameof(str));
                if (isNum)
                {
                    if (Side <= 0 || Side >= int.MaxValue) throw new ArgumentException(nameof(Side));
                    var Area = Math.Pow(Side,2);
                    Console.WriteLine($"Area of this square with Side = {Side}  S=\t{Area}");
                }
            }
            catch (ArgumentException)
            {
                Alert();
            }
        }
        static void RectArea()
        {
            Console.Write("\nPlease enter Side A :");
            try
            {
                string str = Console.ReadLine().Replace(".", ",");
                Console.Write("\nPlease enter Side B :");
                string str1 = Console.ReadLine().Replace(".", ",");
                double SideA;
                double SideB;
                bool isNum = double.TryParse(str, out SideA);
                bool isNum2 = double.TryParse(str1, out SideB);
                if (!isNum || !isNum2) throw new ArgumentException(nameof(str),nameof(str1));
                if (isNum && isNum2)
                {
                    if (SideA <= 0 || SideA >= int.MaxValue) throw new ArgumentException(nameof(SideA));
                    if (SideB <= 0 || SideB >= int.MaxValue) throw new ArgumentException(nameof(SideB));
                    var Area = SideA * SideB;
                    Console.WriteLine($"Area of this rect with A = {SideA} B = {SideB}  S=\t{Area}");
                }
            }
            catch (ArgumentException)
            {
                Alert();
            }
        }
        static void TriangleArea()
        {
            Console.Write("\nPlease enter Side A :");
            try
            {
                string str = Console.ReadLine().Replace(".", ",");
                Console.Write("\nPlease enter Side B :");
                string str1 = Console.ReadLine().Replace(".", ",");
                Console.Write("\nPlease enter Side C :");
                string str2 = Console.ReadLine().Replace(".", ",");

                double SideA;
                double SideB;
                double SideC;

                bool isNum = double.TryParse(str, out SideA);
                bool isNum2 = double.TryParse(str1, out SideB);
                bool isNum3 = double.TryParse(str2, out SideC);

                if (!isNum || !isNum2 || !isNum3) throw new ArgumentException("Not good trianle");
                if (isNum && isNum2 && isNum3)
                {
                    if (SideA <= 0 || SideA >= int.MaxValue) throw new ArgumentException(nameof(SideA));
                    if (SideB <= 0 || SideB >= int.MaxValue) throw new ArgumentException(nameof(SideB));
                    if (SideC <= 0 || SideC >= int.MaxValue) throw new ArgumentException(nameof(SideC));
                    if (SideA + SideB > SideC)
                    {
                        if (SideA + SideC > SideB)
                        {
                            if (SideB + SideC > SideA)
                            {
                                var p = (SideA + SideB + SideC)/2; 
                                var Area = Math.Sqrt(p*(p-SideA)*(p-SideB)*(p-SideC));
                                Console.WriteLine($"Area of this triangle with A = {SideA} B = {SideB} C ={SideC}  S=\t{Area}");
                            }
                            else throw new ArgumentException(nameof(SideA));
                        }
                        else throw new ArgumentException(nameof(SideB));
                    }
                    else throw new ArgumentException(nameof(SideC));
                }
            }
            catch (ArgumentException)
            {
                Alert();
            }
        }
        static double ScriptS(string[] args)
        {
            return Math.PI * Math.Pow(double.Parse(args[1]), 2);
        }
    }
}
