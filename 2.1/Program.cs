using System;
using System.Text;

namespace _2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Instruction();

            string[] Bot = new string[] { "Stone", "Scissors", "Paper" };
            string player;
            string bot;
            int YourScore = 0;
            int BotScore = 0;
            StringBuilder sb = new StringBuilder();
            Console.WriteLine("Lets start!\n\n" +
                "PRESS ANY KEY ON YOUR KEYBOARD!!!\n");

            Console.ReadKey();
            while (true)
            {
                Console.Write("Your move : ");
                player = Console.ReadLine();
                bot = Bot[new Random().Next(0, Bot.Length)];
                var tempB = bot;
                var tempU = player;
                Console.WriteLine($"Bot move: {bot}");
                if (player.ToLower() == "exit")
                {
                    Console.WriteLine($"See you next time!\n" +
                        $"Statistic:\n" +
                        $"{sb}");
                    break;
                }
                if (player.ToLower() == "stone" && bot.ToLower() == "stone")
                {
                    sb.AppendFormat("\nDRAW!(You = '{2}' Bot = '{3}')\nYour Score: {0}\nBots score: {1}\n", YourScore, BotScore,tempU,tempB);
                    continue;
                }
                if (player.ToLower() == "scissors" && bot.ToLower() == "scissors")
                {
                    sb.AppendFormat("\nDRAW!(You = '{2}' Bot = '{3}')\nYour Score: {0}\nBots score: {1}\n", YourScore, BotScore, tempU, tempB);
                    continue;
                }
                if (player.ToLower() == "paper" && bot.ToLower() == "paper")
                {
                    sb.AppendFormat("\nDRAW!(You = '{2}' Bot = '{3}')\nYour Score: {0}\nBots score: {1}\n", YourScore, BotScore, tempU, tempB);
                    continue;
                }

                if (player.ToLower() == "stone" && bot.ToLower() == "scissors")
                {
                    YourScore++;
                   
                    sb.AppendFormat("\nYou wins!(You = '{2}' Bot = '{3}')\nYour Score: {0}\nBots score: {1}\n", YourScore, BotScore, tempU, tempB);
                    continue;
                }
                if (player.ToLower() == "stone" && bot.ToLower() == "paper")
                {
                    BotScore++;
                    sb.AppendFormat("\nBot wins!(You = '{2}' Bot = '{3}')\nYour Score: {0}\nBots score: {1}\n", YourScore, BotScore, tempU, tempB);
                    continue;
                }

                if (player.ToLower() == "scissors" && bot.ToLower() == "paper")
                {
                    YourScore++;
                    sb.AppendFormat("\nYou wins!(You = '{2}' Bot = '{3}')\nYour Score: {0}\nBots score: {1}\n", YourScore, BotScore, tempU, tempB);
                    continue;
                }
                if (player.ToLower() == "scissors" && bot.ToLower() == "stone")
                {
                    BotScore++;
                    sb.AppendFormat("\nBot wins!(You = '{2}' Bot = '{3}')\nYour Score: {0}\nBots score: {1}\n", YourScore, BotScore, tempU, tempB);
                    continue;
                }

                if (player.ToLower() == "paper" && bot.ToLower() == "stone")
                {
                    YourScore++;
                    sb.AppendFormat("\nYou wins!(You = '{2}' Bot = '{3}')\nYour Score: {0}\nBots score: {1}\n", YourScore, BotScore, tempU, tempB);
                    continue;
                }
                if (player.ToLower() == "paper" && bot.ToLower() == "scissors")
                {
                    BotScore++;
                    sb.AppendFormat("\nBot wins!(You = '{2}' Bot = '{3}')\nYour Score: {0}\nBots score: {1}\n", YourScore, BotScore, tempU, tempB);
                    continue;
                }

                if (player.ToLower() != "paper" && player.ToLower() != "stone" && player.ToLower() != "exit" && player.ToLower() != "scissors")
                {
                    InvalidCommand();
                    continue;
                }
                Console.WriteLine();
            }
            Console.WriteLine("RESULTS:\n");
            Console.WriteLine($"Your score : {YourScore}\n" +
                $"Bot score: {BotScore}");
            Console.ReadKey();
        }
        static void Instruction()
        {
            Console.WriteLine("2.1 Hi bro!\n" +
                "Try to play rock-paper-scissors with the computer!\n" +
                "The game is very simple and everything that\n" +
                "is required of you is written in the instructions!\n");
            Console.WriteLine("INSTRUCTION\n" +
                "In this Game Available this instructions:\n" +
                "1. Stone\t(If you want to show off a 'STONE')\n" +
                "2. Scissors\t(If you want to show off a 'SCISSORS')\n" +
                "3. Paper\t(If you want to show off a 'PAPER')\n" +
                "4. Exit\t\t(If you want to stop playing and see the statistics of this game session)\n");
            Console.WriteLine("Common winning combinations:\n" +
                "Stone > Scissors\tScore + 1\n" +
                "Scissors > Paper\tScore + 1\n" +
                "Paper > Stone\t\tScore + 1");
            Console.WriteLine();
        }
        static void InvalidCommand()
        {
            Console.WriteLine("\nOops,You entered the wrong command!\n" +
                "Please see again the list of possible commands:\n" +
                "1. Stone\t(If you want to show off a 'STONE')\n" +
                "2. Scissors\t(If you want to show off a 'SCISSORS')\n" +
                "3. Paper\t(If you want to show off a 'PAPER')\n" +
                "4. Exit\t\t(If you want to stop playing and see the statistics of this game session)\n");
        }
    }
}
