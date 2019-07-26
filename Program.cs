using System;

namespace FizzBuzz
{
    /// <summary>
    /// I heard that this high school algorithmical problem been used at jobs interview
    /// But nobody asked me it until recently, and to my shame, I was overconfident, 
    /// and put condition "if divisible by 15" after other ifs, which made it unreachable
    /// 
    /// So I'm writing it now, because even simple problems needs to be trained. 
    /// Two solutions are below, 
    /// first example FizzBuzz_StringConcatinationSolution demos "easy to read by others" approach
    /// second approach is rather standard
    /// 
    /// Fizz Buzz algorithm
    /// 
    /// Serge Klokov 2019
    /// 
    /// Used .Net Core for this problem
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            FizzBuzz_ClassicalSolution();

            FizzBuzz_StringConcatinationSolution();

            FizzBuzz_ElvisSolution();

            Console.WriteLine("Press any key..");
            Console.ReadKey();
        }

        private static string FizzBuzz_StringConcatinationSolution()
        {
            string s = "";

            for (int i = 0; i < 100; i++)
            {
                bool divisibleBy3 = i % 3 == 0;
                bool divisibleBy5 = i % 5 == 0;
                bool notDivisibleBy3and5 = !divisibleBy3 && !divisibleBy5;

                if (notDivisibleBy3and5)
                {
                    s += i;
                    continue;
                }

                if (divisibleBy3)
                    s += "Fizz";

                if (divisibleBy5)
                    s += "Buzz";

            }

            Console.WriteLine(s);
            Console.WriteLine();
            return s;
        }

        private static void FizzBuzz_ClassicalSolution()
        {
            for (int i = 0; i < 100; i++)
            {
                if (i % 15 == 0)   // I made bug here on job interview, put this line at the bottom of ifs, which made it unreachable
                    Console.Write("FizzBuzz");
                else if (i % 3 == 0)
                    Console.Write("Fizz");
                else if (i % 5 == 0)
                    Console.Write("Buzz");
                else
                    Console.Write(i);
            }

            Console.WriteLine();
            Console.WriteLine();
        }

        // let's use ternary operator (Elvis Operator )
        private static void FizzBuzz_ElvisSolution()
        {
            for (int i = 0; i < 100; i++)
            {
                    string res = (i % 3 == 0 && i % 5 == 0) ? "FizzBuzz" : 
                        (i % 3 == 0) ? "Fizz" :
                        (i % 5 == 0) ? "Buzz" :
                        i.ToString();

                    Console.Write(res);
            }

            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
