using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace euler1
{
    /// <summary>
    /// Project Euler #10: Summation of primes
    /// </summary>
    public class Problem10
    {
        public static void Exec()
        {
            var row = int.Parse(Console.ReadLine());
            var rArray = new int[row];
            for (int r = 0; r < row; r++)
            {
                var NN = Console.ReadLine();
                int N;
                int.TryParse(NN, out N);
                rArray[r] = N;
            }
            var primes = ESieve(rArray.Max());
            for (int r = 0; r < row; r++)
            {
                var N = rArray[r];
                Console.WriteLine(sumOfPrimes(N, primes));
            }
        }

        public static long sumOfPrimes(int n, int[] primes)
        {
            //get primes
            long sum = 0;

            for (int i = 0; i < primes.Length; i++)
            {
                if (primes[i] > n)
                    break;
                sum += primes[i];
            }

            return sum;
        }

        public static int[] ESieve(int upperLimit)
        {

            int sieveBound = (int)(upperLimit - 1) / 2;
            int upperSqrt = ((int)Math.Sqrt(upperLimit) - 1) / 2;

            BitArray PrimeBits = new BitArray(sieveBound + 1, true);

            for (int i = 1; i <= upperSqrt; i++)
            {
                if (PrimeBits.Get(i))
                {
                    for (int j = i * 2 * (i + 1); j <= sieveBound; j += 2 * i + 1)
                    {
                        PrimeBits.Set(j, false);
                    }
                }
            }

            List<int> numbers = new List<int>((int)(upperLimit / (Math.Log(upperLimit) - 1.08366)));
            numbers.Add(2);
            for (int i = 1; i <= sieveBound; i++)
            {
                if (PrimeBits.Get(i))
                {
                    numbers.Add(2 * i + 1);
                }
            }

            return numbers.ToArray();
        }
    }
}
