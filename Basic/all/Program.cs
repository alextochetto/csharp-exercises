using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace all
{
    [MemoryDiagnoser]
    public class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run(typeof(Solution));
        }
    }

    public class Solution
    {
        [Benchmark]
        public void PrintSumPrimeNumbers_DefaultSolution()
        {
            int n = 500;
            //Console.WriteLine($"Sum of the first {n} prime numbers");
            int sum = 0;
            int number = 2;
            int control = 0;
            while (control < n)
            {
                if (number == 2)
                {
                    sum += number;
                    number++;
                    control++;
                    continue;
                }

                int x = (int)Math.Floor(Math.Sqrt(number));
                bool isPrime = true;
                for (int i = 2; i <= x; ++i)
                {
                    if (number % i == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    sum += number;
                    control++;
                }
                number++;
            }
            //Console.WriteLine($"Total sum of the first {n} prime numbers: {sum}");
        }

        [Benchmark]
        public void PrintSumPrimeNumbers_AlternativeSolution()
        {
            int n = 500;
            //Console.WriteLine($"Sum of the first {n} prime numbers");
            int sum = 0;
            int number = 2;
            int control = 0;
            while (control < n)
            {
                if (number == 2)
                {
                    sum += number;
                    number++;
                    control++;
                    continue;
                }

                double y = Math.Floor(Math.Sqrt(number));
                int x = (int)y;
                bool isPrime = true;
                if (y % 1 == 0)
                {
                    for (int i = x; i >= 2; --i)
                    {
                        if (number % i == 0)
                        {
                            isPrime = false;
                            break;
                        }
                    }
                }
                else
                {
                    for (int i = 2; i <= x; ++i)
                    {
                        if (number % i == 0)
                        {
                            isPrime = false;
                            break;
                        }
                    }
                }
                if (isPrime)
                {
                    sum += number;
                    control++;
                }
                number++;
            }
            //Console.WriteLine($"Total sum of the first {n} prime numbers: {sum}");
        }
    }
}
