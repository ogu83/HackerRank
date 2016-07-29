using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AntiPrime
{
    public class Main
    {
        public static void Exec()
        {
            //var row = int.Parse(Console.ReadLine());
            //var x = new int[row];
            //var ax = new int[row];
            //for (int r = 0; r < row; r++)
            //    x[r] = int.Parse(Console.ReadLine());

            //var primes = ESieve(x.Max());

            //for (int r = 0; r < row; r++)
            //{
            //    var xr = x[r];
            //    var pxr = PrimeFactorisationNoD(xr, primes);               
            //}


            var row = int.Parse(Console.ReadLine());
            var x = new int[row];
            var ax = new int[row];
            for (int r = 0; r < row; r++)
                x[r] = int.Parse(Console.ReadLine());

            var primes = ESieve(x.Max());

            var n = 2;
            var nd = 2;
            while (n <= x.Max())
            {
                while (PrimeFactorisationNoD(n, primes) <= nd)
                    n++;
                nd = PrimeFactorisationNoD(n, primes);
                for (int r = 0; r < row; r++)
                    if (x[r] < n && ax[r] == 0)
                        ax[r] = n;
            }

            for (int r = 0; r < row; r++)
            {
                if (ax[r] == 0) ax[r] = 2;
                Console.WriteLine(ax[r]);

            }


            //var row = int.Parse(Console.ReadLine());
            //for (int r = 0; r < row; r++)
            //{
            //    var x = int.Parse(Console.ReadLine());
            //    var xd = 0;
            //    var lI = 0;
            //    var lId = 0;
            //    for (int i = 0; i < x; i++)
            //    {
            //        //if (lI > 2)
            //        //    if (i % lI != 0)
            //        //        continue;

            //        int id = 0;
            //        id = divisors(i);
            //        if (id > xd)
            //        {
            //            xd = id;
            //            lId = id;
            //            lI = i;
            //        }
            //    }

            //    var nd = 0;
            //    var n = x;
            //    while (nd < xd)
            //    {
            //        n++;
            //        nd = divisors(n);
            //    }
            //    Console.WriteLine(n);
            //}
        }

        public static int PrimeFactorisationNoD(int number, int[] primelist)
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

        static int divisors(int x)
        {
            int limit = x;
            int numberOfDivisors = 0;

            if (x == 1) return 1;

            for (int i = 1; i < limit; ++i)
            {
                if (x % i == 0)
                {
                    limit = x / i;
                    if (limit != i)
                    {
                        numberOfDivisors++;
                    }
                    numberOfDivisors++;
                }
            }

            return numberOfDivisors;
        }
    }
}
