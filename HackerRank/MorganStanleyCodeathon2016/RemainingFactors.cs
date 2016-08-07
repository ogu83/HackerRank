using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace MorganStanleyCodeathon2016
{
    public class RemainingFactors
    {
        static int[] ESieve(int upperLimit)
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

        static int PrimeFactorisationNoD(int number, int[] primelist)
        {
            int nod = 1;
            int exponent;
            int remain = number;

            for (int i = 0; i < primelist.Length; i++)
            {

                // In case there is a remainder this is a prime factor as well
                // The exponent of that factor is 1
                if (primelist[i] * primelist[i] > number)
                {
                    return nod * 2;
                }

                exponent = 1;
                while (remain % primelist[i] == 0)
                {
                    exponent++;
                    remain = remain / primelist[i];
                }
                nod *= exponent;

                //If there is no remainder, return the count
                if (remain == 1)
                {
                    return nod;
                }
            }
            return nod;
        }

        static int NumberOfDivisors(int number)
        {
            int nod = 0;
            int sqrt = (int)Math.Sqrt(number);

            for (int i = 1; i <= sqrt; i++)
            {
                if (number % i == 0)
                {
                    nod += 2;
                }
            }
            //Correction if the number is a perfect square
            if (sqrt * sqrt == number)
            {
                nod--;
            }

            return nod;
        }


        static IEnumerable<int> GetDivisors(int n)
        {
            return from a in Enumerable.Range(2, n)
                   where (n * n) % a == 0 && n % a > 0
                   select a;
        }

        static IEnumerable<long> GetFactors(long num)
        {
            for (long factor = 1; factor * factor <= num; factor++)
            {
                if (num % factor == 0)
                {
                    yield return factor;
                    if (factor * factor != num)
                        yield return num / factor;
                }
            }
        }

        public static void Exec()
        {
            var N = BigInteger.Parse(Console.ReadLine());
            BigInteger N2 = N * N;
            BigInteger nod = 0;

            //var primeList = ESieve(75000);
            //if (!primeList.Contains((int)N))
            {
                for (BigInteger factor = 1; factor * factor <= N2; factor++)
                {
                    if (N2 % factor == 0 && N % factor > 0 && factor < N)
                    {
                        nod++;
                    }
                }
            }
            Console.WriteLine(nod);
        }
    }
}
