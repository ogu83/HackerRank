using System;
using System.Collections.Generic;

namespace euler1
{
    /// <summary>
    /// Project Euler #5: Smallest multiple
    /// </summary>
    public class Problem5
    {
        public static void Exec()
        {
            var row = int.Parse(Console.ReadLine());
            for (int r = 0; r < row; r++)
            {
                var NN = Console.ReadLine();
                int N;
                int.TryParse(NN, out N);
                int divisorMax = N;
                int[] p = generatePrimes(divisorMax);
                int result = 1;

                for (int i = 0; i < p.Length; i++)
                {
                    int a = (int)Math.Floor(Math.Log(divisorMax) / Math.Log(p[i]));
                    result = result * ((int)Math.Pow(p[i], a));
                }
                Console.WriteLine(result);
            }
        }

        private static int[] generatePrimes(int upperLimit)
        {
            List<int> primes = new List<int>();
            bool isPrime;
            int j;

            primes.Add(2);

            for (int i = 3; i <= upperLimit; i += 2)
            {
                j = 0;
                isPrime = true;
                while (primes[j] * primes[j] <= i)
                {
                    if (i % primes[j] == 0)
                    {
                        isPrime = false;
                        break;
                    }
                    j++;
                }
                if (isPrime)
                {
                    primes.Add(i);
                }
            }

            return primes.ToArray();
        }
    }

    
}
