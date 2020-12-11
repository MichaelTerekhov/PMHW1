using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _3._1
{
    /// <summary>
    /// This is a crude project, but in the interactive mode the functionality is developed by 75-80%
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("3.1 Hey, Bro!\n" +
                    "Welcome to the free version of the smart calculator!\n" +
                    "Includes simple binary, binary bitwise, unary and unary bitwise operators" +
                    "(c)Michael Terekhov\n\n" +
                    "If you want to know the possible operations, write: help.\n\n" +
                    "If you want to leave the application write: exit\n");
                string query;
            
                    while (true)
                    {
                    try
                    { 
                        Console.Write("Your command> ");
                        query = Console.ReadLine().ToLower();
                        if (query == "exit")
                        {
                            Console.WriteLine("See you next time!");
                            break;
                        }
                        if (query == "help")
                        {
                            Instruction();
                            continue;
                        }
                        char[] oper = new char[] {'+','-','*','x','/','!','%', '&', '|', '^' };
                        string normalzed = query.ToLower().Replace(" ", "").Replace(".", ",");
                        string temp = normalzed + "e";

                       
                        if (!int.TryParse(Convert.ToString(normalzed[0]), out int binary) && Char.IsLetter(normalzed[0]))
                        {
                            var Plug = normalzed[0];
                            throw new ArgumentException(nameof(Plug));
                        }
                        string buff = "";
                        int count = 0;
                        int countBound = 0;
                        for (int i = 0; i < temp.Length; i++)
                        {
                            if (Double.TryParse(Convert.ToString(temp[i]), out double Plug))
                            {
                                buff += temp[i];
                            }
                            if(temp[i] == ',')
                            {
                                countBound++;
                                continue;
                            }
                            else
                            {
                                if (buff != "")
                                {
                                    count++;
                                    buff = "";
                                }
                            }

                        }
                        if (count > 2 || countBound > 2) throw new ArgumentException(nameof(count),nameof(countBound));
                        Parsing(normalzed);
                    }
                    catch (ArgumentException)
                    {
                      Console.WriteLine("You entered wrong expression!\n");
                      Instruction();
                      continue;
                    }
            
                }
   
            }
            Console.ReadKey();
        }

        static void Parsing(string s)
        {
            double num;
            int binary;
            ArrayList list = new ArrayList();
            string unaryPA = s;
            string binaryPa = s + "m";
            int unary;
            var binoper = "";
            int.TryParse(string.Join("", unaryPA.Where(c => char.IsDigit(c))), out unary);
            if (unaryPA[0] == '!')
            {
                list.Add(Convert.ToString(unaryPA[0]));
                list.Add(unary);
                Calculation(list);
                return;
            }
            if (unaryPA[unaryPA.Length - 1] == '!')
            {
                list.Add(unary);
                list.Add(Convert.ToString(unaryPA[unaryPA.Length - 1]));
                Calculation(list);
                return;
            }
            foreach(var m in binaryPa)
            {
                if (m == '&') binoper = Convert.ToString(m);
                if (m == '|') binoper = Convert.ToString(m);
                if (m == '^') binoper = Convert.ToString(m);
            }
            string Buffer = "";
            if (binoper == "&" || binoper == "|" || binoper == "^")
            {
                for (int i = 0; i < binaryPa.Length  ; i++)
                {
                    if (int.TryParse(Convert.ToString(binaryPa[i]), out binary))
                    {
                        Buffer += binaryPa[i];
                    }
                    else
                    {
                        if (Buffer != "")
                        {
                            list.Add(Buffer);
                            Buffer = "";
                        }
                    }
                    if (i == binaryPa.Length-1) list.Add(binoper);
                }
                Calculation(list);
                return;
            }
            string temp="";
            string buf = "";
            string copied = s + "l";
            if(s.Length < 3)
            {
                foreach (var m in s)
                {
                    list.Add(m);
                }
                Calculation(list);
            }
            if (copied.Length > 3)
            {
                for (int i = 0; i < copied.Length; i++)
                {
                    if (copied[i] == ',')
                    {
                        for (int j = i + 1; j < copied.Length; j++)
                        {
                            if (Double.TryParse(Convert.ToString(copied[j]), out num))
                            {
                                buf += copied[j];
                            }
                            if (!Double.TryParse(Convert.ToString(copied[j]), out num))break;
                        }
                        string buf1 = "";
                        for (int m = i - 1; m >= 0; m--)
                        {
                            if (Double.TryParse(Convert.ToString(copied[m]), out num))
                            {
                                buf1 = copied[m] + buf1;
                            }
                            if (!Double.TryParse(Convert.ToString(copied[m]), out num)) break;
                        }
                        temp = String.Concat(buf1 + Convert.ToString(copied[i]) + buf);
                        buf = "";
                        buf1 = "";
                        int Plug = 0;
                        int count = (copied.Length - copied.Replace(temp, "").Length) / temp.Length;
                        if (count >= 2)
                        {
                            list.Add(double.Parse(temp));
                        }
                        copied = copied.Replace(temp, "");
                        list.Add(double.Parse(temp));
                        temp = " ";
                    }
                }
                buf = "";
                for (int i = 0; i < copied.Length; i++)
                {
                    if (Double.TryParse(Convert.ToString(copied[i]), out num))
                    {
                            buf += copied[i];
                    }
                    else
                    {
                        if (buf != "")
                        {
                            list.Add(buf);
                            buf = "";
                        }
                    }

                }
                for (int i = 0; i < copied.Length; i++)
                {
                    if (copied[i] == '+' || copied[i] == '-' || copied[i] == '*' || copied[i] == '/' || copied[i] == 'x' || copied[i] == '\'' || copied[i] == '%')
                    {
                        temp = Convert.ToString(copied[i]);
                        list.Add(temp);
                    }
                    if (Convert.ToString(copied[i]) == "p" && Convert.ToString(copied[i+1]) == "o" && Convert.ToString(copied[i+2]) == "w")
                    {
                        list.Add("pow");
                    }
                }
               
                Calculation(list);
            }
        }
        static void Calculation(ArrayList list)
        {
            double num;
            for (int i = list.Count - 1; i >= 0; i--)
            {
                if (Convert.ToString(list[i]) == "pow")
                {
                    Console.WriteLine($"{Math.Pow(Convert.ToDouble(list[0]), Convert.ToDouble(list[1]))}");
                    break;
                }
                if (Convert.ToString(list[i]) == "%")
                {
                    Console.WriteLine($"{ Convert.ToDouble(list[0]) % Convert.ToDouble(list[1])}");
                    break;
                }
                if ((Convert.ToChar(list[i]) == '/' ) && Convert.ToString(list[i - 1]) == "-")
                {
                    try
                    {
                        double Plug = Convert.ToDouble(list[1]);
                        if (Plug == 0d) throw new DivideByZeroException(nameof(Plug));
                        Console.WriteLine($"{ -((Convert.ToDouble(list[0])) / Convert.ToDouble(list[1]))}");
                    }
                    catch (DivideByZeroException)
                    {
                        Console.WriteLine($"{ -Convert.ToDouble(list[0]) / Convert.ToDouble(list[1])}");
                    }
                    break;
                }
                if (Convert.ToChar(list[i]) == '/')
                {
                    try
                    {
                        double Plug = Convert.ToDouble(list[1]);
                        if (Plug == 0d) throw new DivideByZeroException(nameof(Plug));
                        Console.WriteLine($"{ Convert.ToDouble(list[0]) / Convert.ToDouble(list[1])}");
                    }
                    catch (DivideByZeroException)
                    {
                        Console.WriteLine($"{ Convert.ToDouble(list[0]) / Convert.ToDouble(list[1])}");
                    }
                    break;
                }
                if (Convert.ToString(list[i]) == "-" && (Convert.ToChar(list[i - 1]) == '/'))
                {
                    try
                    {
                        double Plug = Convert.ToDouble(list[1]);
                        if (Plug == 0d) throw new DivideByZeroException(nameof(Plug));
                        Console.WriteLine($"{ Convert.ToDouble(list[0]) / -Convert.ToDouble(list[1])}");
                    }
                    catch (DivideByZeroException)
                    {
                        Console.WriteLine($"{ Convert.ToDouble(list[0]) / -Convert.ToDouble(list[1])}");
                    }
                    break;
                }
                if (Convert.ToString(list[i]) == "-" && (Convert.ToChar(list[i - 1]) == '/' ) && Convert.ToString(list[i - 2]) == "-")
                {
                    try
                    {
                        double Plug = Convert.ToDouble(list[1]);
                        if (Plug == 0d) throw new DivideByZeroException(nameof(Plug));
                        Console.WriteLine($"{ Convert.ToDouble(list[0]) / Convert.ToDouble(list[1])}");
                    }
                    catch (DivideByZeroException)
                    {
                        Console.WriteLine($"{ Convert.ToDouble(list[0]) / Convert.ToDouble(list[1])}");
                    }
                    break;
                }
                if ((Convert.ToString(list[i]) == "*" || (Convert.ToString(list[i]) == "x") && Convert.ToString(list[i-1]) == "-"))
                {
                    Console.WriteLine($"{ -Convert.ToDouble(list[0]) * Convert.ToDouble(list[1])}");
                    break;
                }
                if (Convert.ToString(list[i]) == "-" && (Convert.ToString(list[i - 1]) == "*" || Convert.ToString(list[i - 1]) == "x") && Convert.ToString(list[i - 2]) == "-")
                {
                    Console.WriteLine($"{ (Math.Abs(Convert.ToDouble(list[0])) * Math.Abs(Convert.ToDouble(list[1])))}");
                    break;
                }
                if (Convert.ToString(list[i]) == "+" && Convert.ToString(list[i - 1]) == "-")
                {
                    Console.WriteLine($"{ -Convert.ToDouble(list[0]) + Convert.ToDouble(list[1])}");
                    break;
                }
                if (Convert.ToString(list[i]) == "-" && Convert.ToString(list[i - 1]) == "-" && Convert.ToString(list[i - 2]) == "-")
                {
                    Console.WriteLine($"{ -Convert.ToDouble(list[0]) + Convert.ToDouble(list[1])}");
                    break;
                }
                if (Convert.ToString(list[i]) == "-" && Convert.ToString(list[i - 1]) == "+")
                {
                    Console.WriteLine($"{ Convert.ToDouble(list[0]) +  (-Convert.ToDouble(list[1]))}");
                    break;
                }
                if (Convert.ToString(list[i]) == "-" && Convert.ToString(list[i - 1]) == "-")
                {
                    Console.WriteLine($"{ Convert.ToDouble(list[0]) + Convert.ToDouble(list[1])}");
                    break;
                }
                if (Convert.ToString(list[i]) == "-" && (Convert.ToString(list[i - 1]) == "*" || (Convert.ToString(list[i - 1]) == "x")))
                {
                    Console.WriteLine($"{ Convert.ToDouble(list[0]) * -Convert.ToDouble(list[1])}");
                    break;
                }
                if (Convert.ToString(list[i]) == "*" || Convert.ToString(list[i]) == "x") Console.WriteLine($"{ Convert.ToDouble(list[0]) * Convert.ToDouble(list[1])}");
                if (Convert.ToString(list[i]) == "-") Console.WriteLine($"{ Convert.ToDouble(list[0]) - Convert.ToDouble(list[1])}");
                if (Convert.ToString(list[i]) == "+")Console.WriteLine($"{ Convert.ToDouble(list[0]) + Convert.ToDouble(list[1])}");
                if (Convert.ToString(list[i]) == "&") Console.WriteLine($"{ Convert.ToInt32(list[0]) & Convert.ToInt32(list[1])}");
                if (Convert.ToString(list[i]) == "|") Console.WriteLine($"{ Convert.ToInt32(list[0]) | Convert.ToInt32(list[1])}");
                if (Convert.ToString(list[i]) == "^") Console.WriteLine($"{ Convert.ToInt32(list[0]) ^ Convert.ToInt32(list[1])}");
               

            }
            if(list.Count == 1)
                Console.WriteLine($"{list[0]}");
            if (list.Count == 2 && Convert.ToString(list[0]) == "-")
                Console.WriteLine($"{list[1]}");
            if (list.Count == 2 && Convert.ToString(list[0]) == "!")
                Console.WriteLine($"{~Convert.ToInt32(list[1])}");
            if (list.Count == 2 && Convert.ToString(list[1]) == "!")
                Console.WriteLine($"{Factorial(Convert.ToUInt64(list[0]))}");

        }
        static ulong Factorial(ulong  x)
        {
            try
            {

                    if (x > ulong.MaxValue) throw new ArgumentOutOfRangeException(nameof(x));
                    if (x == 0)
                    {
                        return 1;
                    }
                    else
                    {
                        return x * Factorial(x - 1);
                    }        
            }
            catch (ArgumentOutOfRangeException)
            {
                return Convert.ToUInt64(-1);
            }
            return 0;
        }
        static void Instruction()
        {
            Console.WriteLine("\nYou are given the opportunity to perform certain operations\n" +
                "with ONE or TWO any numbers!\n" +
                "\nList of operations:\n" +
                "1. Binary: +, -, *(alternative 'x'), / (alternative '\'),%, pow (a to power b)\n" +
                "Example: 1 + 4 , -2 pow 4, 4 x 2\n" +
                "2. Binary bitwise: &, |, ^. ONLY POSITIVE OPERAND\n" +
                "Example: 3 | 5\n" +
                "3. Unary bitwise: !. ONLY POSITIVE OPERAND\n" +
                "Example: !5\n" +
                "4. Unary: a! (factorial), a (echo mode), -a (echo mode)\n" +
                "Example: 3!\n\n");
        }
    }
}
