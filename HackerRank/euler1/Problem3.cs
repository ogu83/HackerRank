using System;
using System.Collections.Generic;
using System.Linq;

namespace euler1
{
    /// <summary>
    /// Largest Prime Factor
    /// </summary>
    public class Problem3
    {
        public static void Exec()
        {
            var row = int.Parse(Console.ReadLine());
            for (int r = 0; r < row; r++)
            {
                var NN = Console.ReadLine();
                long N;
                long.TryParse(NN, out N);

                if (N < 2)
                    Console.WriteLine(N);
                else
                {
                    var result = potentialFactors(N).Max();
                    Console.WriteLine(result);
                }
            }
        }

        private static IEnumerable<long> potentialFactors(long num)
        {
            yield return 2;
            yield return 3;
            var fact = 5;
            var incr = 2;
            while (fact * fact <= num)
            {
                yield return fact;
                fact += incr;
                incr ^= 6;
            }            
        }

        private static IEnumerable<long> primeFactors(long n)
        {
            long d = 2;
            while (n > 1)
            {
                while (n % d == 0)
                {
                    yield return d;
                    n /= d;
                }
                d++;
            }
        }
    }
}