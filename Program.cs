using System;
using System.Collections.Generic;
using System.Linq;


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
    /// I used .Net Core and Visual Studio 2019 for this problem, 
    /// however it's no difference from standard .Net, because of simplicity
    /// 
    /// Some URLs below to read:
    /// http://wiki.c2.com/?FizzBuzzTest
    /// https://exceptionnotfound.net/a-definitive-fizzbuzz-solution-guide-in-c-sharp/
    /// https://stackoverflow.com/questions/11764539/writing-fizzbuzz
    /// 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            FizzBuzz_ClassicalSolution();

            FizzBuzz_StringConcatinationSolution();

            FizzBuzz_ElvisSolution();

            FizzBuzzLinqLoop();

            FizzBuzzLinq2();

            FizzBuzzLinq3NoLoop();

            FizzBuzz_Pattern(); // let's keep this solution last

            Console.WriteLine("Press any key..");
            Console.ReadKey();
        }

        // This is example of "human readable" and self describing coding
        // It was my initial solution, whithout use external help
        // However it need to put result in one line, and not in several strings
        // If you will need to put each element on separate line, you will have to add a boolean value set false
        // and modify it after 3 & 5 Write 
        // insertNewline = true; 
        // and insert new line at the bottom of the loop based on boolean value
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
                    s += i;   // note, because of type autoconversion it's the same as s = s + i.ToString(); 
                    continue;
                }

                // expense of the output's formatting, we can't use WriteLine here ..
                if (divisibleBy3)
                    s += "Fizz";

                // .. and here
                if (divisibleBy5)
                    s += "Buzz";

            }

            Console.WriteLine(s);
            Console.WriteLine();
            return s;
        }


        // This is very typical implementation
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
        // it's the shortest code I believe, however reading by other developers it could be difficult, 
        // so I don't vote for it
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

        // Limitation is that it give result in minimum 15-chunks
        // However it's very efficient
        // and this cycle could be configurable
        private static void FizzBuzz_Pattern()
        {
            Console.WriteLine("Pattern based solution, because of 15-pattern we return 15x7 = 105 values");

            const string FIZZ = "Fizz";
            const string BUZZ = "Buzz";
            const string FIZZBUZZ = "FizzBuzz";

            int i = 0;
            while (i < 15*7)  // 15x7 = 105  
            {
                Console.Write(FIZZBUZZ); i++;
                Console.Write(i++);
                Console.Write(i++);
                Console.Write(FIZZ); i++;
                Console.Write(i++);
                Console.Write(BUZZ); i++;
                Console.Write(FIZZ); i++;
                Console.Write(i++);
                Console.Write(i++);
                Console.Write(FIZZ); i++;
                Console.Write(BUZZ); i++;
                Console.Write(i++);
                Console.Write(FIZZ); i++;
                Console.Write(i++);
                Console.Write(i++);
             }

            Console.WriteLine();
            Console.WriteLine();
        }

        // in fact it's LINQ for each loop 
        // because of Elvis operator it could be one line but I will break it for readability
        private static void FizzBuzzLinqLoop() {
            Enumerable.Range(0, 100)
                .ToList()
                .ForEach(i => Console.Write(
                    i % 3 * i % 5 == 0 
                    ? (i % 3 == 0 ? "Fizz" : "") + (i % 5 == 0 ? "Buzz" : "") 
                    : i.ToString()));

            Console.WriteLine();
            Console.WriteLine();
        }

        private static void FizzBuzzLinq2() {
            var collection = Enumerable.Range(0, 100)
                .Select(i => {
                    if (i % 15 == 0)
                    {
                        return "FizzBuzz";
                    }
                    if (i % 3 == 0)
                    {
                        return "Fizz";
                    }
                    if (i % 5 == 0)
                    {
                        return "Buzz";
                    }
                    return i.ToString();
                });

            collection.ToList().ForEach(i => Console.Write(i));

            Console.WriteLine();
            Console.WriteLine();
        }

        private static void FizzBuzzLinq3NoLoop() {
            Console.WriteLine(
                String.Join(
                  "", //Environment.NewLine, // if needed in a new line
                  Enumerable.Range(0, 100)
                    .Select(i => i % 15 == 0 ? "FizzBuzz"
                               : i % 3 == 0 ? "Fizz"
                               : i % 5 == 0 ? "Buzz"
                               : i.ToString())
                ));

            Console.WriteLine();
        }
    }
}
