using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("It is game called 'Guess the number'");
            Random rand = new Random();
            var randomNumber = CreatRandomNumber(rand);
            var userInput = ReadPos("your number");
            int tryCounter = 1;
            while (userInput != randomNumber)
            {
                if (userInput > randomNumber)
                {
                    Console.WriteLine("Your number is bigger than computer number");
                }
                else if (userInput < randomNumber)
                {
                    Console.WriteLine("Your number is small than computer number");
                }
                userInput = ReadPos("your number again");
                tryCounter++;
            } 
            Console.WriteLine("You are right");
            Console.WriteLine($"The number of attempts is: {tryCounter}");
            Console.Read();
        }

        private static int CreatRandomNumber(Random rend)
        {
            while (true)
            {
            var startPos = ReadPos("intirial range");
            var endPos = ReadPos("end range");
                try
                {
                    var randomNum = rend.Next(startPos, endPos);
                    return randomNum;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        static int ReadPos(string posname)
        {
                do
                {
                    try
                    {
                        Console.WriteLine($"Enter {posname}");
                        var key = Console.ReadKey();
                        if (key.Key == ConsoleKey.Escape)
                        {
                            throw new OperationCanceledException();
                        }
                        var line = Console.ReadLine();
                        var key_line = $"{key.KeyChar}{line}";
                        return Convert.ToInt32(key_line);
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine($"Bed Input {ex.Message}. Enter new or press esc");
                    }
                } while (true);
        }


    }
}
