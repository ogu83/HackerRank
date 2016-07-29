using System;
using System.Collections.Generic;
using System.Linq;

namespace euler1
{
    /// <summary>
    /// Project Euler #7: 10001st prime
    /// </summary>
    public class Problem7
    {
        static bool isPrime(long value)
        {
            if (value < 2) { return false; }
            if (value % 2 == 0) { return value == 2; }
            if (value % 3 == 0) { return value == 3; }
            if (value % 5 == 0) { return value == 5; }
            if (value == 7) { return true; }

            for (int divisor = 7; divisor * divisor <= value; divisor += 30)
            {
                if (value % divisor == 0) { return false; }
                if (value % (divisor + 4) == 0) { return false; }
                if (value % (divisor + 6) == 0) { return false; }
                if (value % (divisor + 10) == 0) { return false; }
                if (value % (divisor + 12) == 0) { return false; }
                if (value % (divisor + 16) == 0) { return false; }
                if (value % (divisor + 22) == 0) { return false; }
                if (value % (divisor + 24) == 0) { return false; }
            }

            return true;
        }

        static IEnumerable<long> PositiveIntegers()
        {
            for (long i = 1; i < long.MaxValue; ++i)
                yield return i;
        }

        static IEnumerable<long> Primes()
        {
            return PositiveIntegers().Where(x => isPrime(x));
        }

        public static void Exec()
        {
            var row = int.Parse(Console.ReadLine());
            for (int r = 0; r < row; r++)
            {
                var NN = Console.ReadLine();
                int N;
                int.TryParse(NN, out N);
                Console.WriteLine(Primes().Skip(N-1).First());
            }
        }
    }
}
